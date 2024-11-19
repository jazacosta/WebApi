using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class EntityProductDTO
{
    public string EntityName { get; set; } = string.Empty;
    public List<ProductDTO> Products { get; set; } = [];
}
