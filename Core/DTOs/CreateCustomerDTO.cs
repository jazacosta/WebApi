namespace Core.DTOs;

public class CreateCustomerDTO
{
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string BirthDate { get; set; } = string.Empty;
}
