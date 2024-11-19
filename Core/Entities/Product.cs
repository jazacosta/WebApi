namespace Core.Entities;

public class Product //EntityProduct
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int EntityId { get; set; }

    public Entity Entity { get; set; } = null!;
    public List<CustomerEntityProduct> CustomerEntityProducts { get; set; } = null!;
}
