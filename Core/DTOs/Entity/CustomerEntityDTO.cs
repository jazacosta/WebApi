using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class CustomerEntityDTO
{
    public string EntityName { get; set; } = string.Empty;

    public List<DetailedProductDTO> Products { get; set; } = null!;
}
