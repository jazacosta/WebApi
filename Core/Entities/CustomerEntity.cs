namespace Core.Entities;

public class CustomerEntity
{
    public int CustomerEntityId { get; set; }
    public int CustomerId { get; set; }
    public int EntityId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Entity Entity { get; set; } = null!;
    public List<CustomerEntityProduct> CustomerEntityProducts { get; set; } = null!;

}
