namespace EcommerceProject.Shared.Dtos;

public record CreateProductDTO(string Name, string Description, decimal Price, int Stock, Guid CategoryId);