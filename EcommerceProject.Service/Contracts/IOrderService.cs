using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface IOrderService
{
    Task<string> Checkout(PayerRequest payerRequest);
    Task Notification(dynamic notification);
}