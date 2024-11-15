namespace Core.Requests;

public class UpdateEntityRequest
{
    public int EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CustomerId { get; set; }
}
