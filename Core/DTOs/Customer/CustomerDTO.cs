using Core.DTOs.Account;

namespace Core.DTOs.Customer;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? BirthDate { get; set; }

    public List<DetailedAccountDTO>? Accounts { get; set; }

}
