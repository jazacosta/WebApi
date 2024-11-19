using System.Globalization;

namespace Core.Entities;

public class Entity
{
    public int EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    //lista de productos
    public List<Product> Products { get; set; } = [];
    //public List<Product> EntityProducts { get; set; } = []; 
    public List<CustomerEntity> CustomerEntities { get; set; } = [];
}
