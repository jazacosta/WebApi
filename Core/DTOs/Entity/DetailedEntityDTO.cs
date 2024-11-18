namespace Core.DTOs.Entity;

public class DetailedEntityDTO
{
    public string CustomerName { get; set; } = string.Empty;
    public int EntityId { get; set; }

    public List<CustomerEntityDTO> CustomerEntities { get; set; } = null!;
}
