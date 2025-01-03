using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;
using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Configurations;
using EcommerceProject.Shared.Dtos;
using MercadoPago.Client.Common;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EcommerceProject.Service.Implementations;

public class OrderService : IOrderService
{
    private IRedisRepository _redisRepository;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;
    private readonly MercadoPagoSettings _mercadoPagoSettings;

    public OrderService(IRedisRepository redisRepository, IOptions<MercadoPagoSettings> mercadoPagoSettings, IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _redisRepository = redisRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mercadoPagoSettings = mercadoPagoSettings.Value;
    }
    public async Task<string> Checkout(PayerRequest payerRequest)
    {
        
        var cartKey = $"cart:{payerRequest.UserId}";
        var cartJson = await _redisRepository.Get(cartKey);
        if (string.IsNullOrEmpty(cartJson))
        {
            throw new Exception("No items in cart");
        }
        var cartItems = JsonConvert.DeserializeObject<List<CartItemDto>>(cartJson);
        var orderId = Guid.NewGuid();
        var products = _productRepository.GetAll().ToList();
        var order = new Order
        {
            Id = orderId,
            UserId = payerRequest.UserId,
            OrderDate = DateTime.UtcNow,
            Total = cartItems.Sum(item => item.Price * item.Quantity),
            PaymentStatus = Order.PaytStatu.Pending,
            OrderDetails = cartItems.Select(item => new OrderDetail
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = item.ProductId,
                Price = item.Price,
                Quantity = item.Quantity,
                Product = products.FirstOrDefault(p => p.Id == item.ProductId),
            }).ToList()
        };
       //var orderAdded = await _orderRepository.Add(order);
       //var cartDeleted =await _redisRepository.Delete(cartKey);
        
        MercadoPagoConfig.AccessToken = _mercadoPagoSettings.AccessToken;

        var request = new PreferenceRequest()
        {
            Items = order.OrderDetails.Select(detail => new PreferenceItemRequest()
            {
                Id = detail.ProductId.ToString(),
                CurrencyId = "ARS",
                Title = detail.Product.Name,
                Quantity = detail.Quantity,
                UnitPrice = detail.Price,
            }).ToList(),
            
            Payer = new PreferencePayerRequest()
            {
                Name = payerRequest.Name,
                Surname = payerRequest.Surname,
                Email = payerRequest.Email,
                Identification = new IdentificationRequest()
                {
                    Type = payerRequest.Type,
                    Number = payerRequest.NumberId,
                },
                Address = new AddressRequest()
                {
                    StreetName = payerRequest.StreetName,
                    StreetNumber = payerRequest.StreetNumber,
                    ZipCode = payerRequest.ZipCode,
                },
                Phone = new PhoneRequest()
                {
                    AreaCode = payerRequest.AreaCode,
                    Number = payerRequest.PhoneNumber,
                }
            },
            BackUrls = new PreferenceBackUrlsRequest()
            {
                Success = "http://localhost:5000/api/payment/success",
                Failure = "http://localhost:5000/api/payment/failure",
                Pending = "http://localhost:5000/api/payment/pending"
            },
            AutoReturn = "approved",
            PaymentMethods = new PreferencePaymentMethodsRequest()
            {
                ExcludedPaymentMethods = [],
                ExcludedPaymentTypes = [],
                Installments = 8
            },
            StatementDescriptor = "EcommerceProject",
            ExternalReference = $"Reference_{orderId.ToString()}",
            Expires = true,
            ExpirationDateFrom = DateTime.Now,
            ExpirationDateTo = DateTime.Now.AddMinutes(10)
        };
        var client = new PreferenceClient();
        var preference = await client.CreateAsync(request);
        return preference.SandboxInitPoint;
    }

    public async Task Notification(dynamic notification)
    {
        string type = notification.type();
        string id = notification.data.id();
        if (type == "payment")
        {
            var payment = await GetPaymentDetails(id);
            string status = payment["status"];
            string externalReference = payment["externalReference"];
            if (Guid.TryParse(externalReference, out var orderId))
            {
                var order = await _orderRepository.GetOrderById(orderId);
                if (order != null)
                {
                    order.PaymentStatus = MapPaymentStatus(status);
                    _orderRepository.UpdateOrderStatus(order);
                }
                else
                {
                    throw new Exception("Order not found");
                }
            }
        }
    }

    private Order.PaytStatu MapPaymentStatus(string status)
    {
        return status switch
        {
            "approved" => Order.PaytStatu.Success,
            "rejected" => Order.PaytStatu.Failure,
            "cancelled" => Order.PaytStatu.Canceled,
            "pending" => Order.PaytStatu.Pending,
            _ => Order.PaytStatu.Pending,
        };
    }

    private async Task<dynamic> GetPaymentDetails(string orderId)
    {
        var url = $"https://api.mercadopago.com/v1/payments/{orderId}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<dynamic>(responseContent);
    }
}