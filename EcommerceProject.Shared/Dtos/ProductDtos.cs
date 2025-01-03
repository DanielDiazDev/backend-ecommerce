namespace EcommerceProject.Shared.Dtos;

public record CreateProductDto(string Name, string Description, decimal Price, int Stock, Guid CategoryId);
public record PaginationResponse<T>(int TotalCount, int PageNumber, int PageSize, IEnumerable<T> Items);
public record ProductDto(string Name, string Description, decimal Price, int Stock, Guid CategoryId);

public class PaginationRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "Name";
    public bool IsDescending { get; set; } = false;
    public string? FilterByName { get; set; } = null;
    public Guid? FilterByCategoryId { get; set; } = null;

}