using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.API.Endpoints;

public static class OrderModule
{
    public static void AddOrderEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("Checkout", async (PayerRequest payerRequest, IOrderService orderService) =>
        {
            var result = await orderService.Checkout(payerRequest);
            return Results.Ok(result);
        });
        app.MapPost("Notification", async (dynamic notification, IOrderService orderService) =>
        {
            try
            {
                await orderService.Notification(notification);
                return Results.Ok("Notification processed successfully.");
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error processing notification: {ex.Message}");
            }
        });
    }
}