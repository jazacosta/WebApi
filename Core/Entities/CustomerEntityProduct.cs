namespace Core.Entities;

public class CustomerEntityProduct
{
    public int CustomerEntityProductId { get; set; }
    public int CustomerEntityId { get; set; }
    public int ProductId { get; set; }
    public CustomerEntity CustomerEntity { get; set; } = null!;
    public Product Products { get; set; } = null!;
}
