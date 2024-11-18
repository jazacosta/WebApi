namespace Core.DTOs.Entity
{
    public class EntityDTO
    {
        public int EntityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public int CustomerId { get; set; }

        //public CustomerDTO Customer { get; set; } = new();

    }
}
