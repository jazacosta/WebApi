using Core.DTOs.Entity;

namespace Core.DTOs.Product;

public class CustomerProductDTO
{
    public string FullName { get; set; } = string.Empty;
    public List<EntityProductDTO> Products { get; set; } = [];
}
