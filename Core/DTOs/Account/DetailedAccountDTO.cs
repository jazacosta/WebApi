using Core.DTOs.Customer;
using Core.Entities;

namespace Core.DTOs.Account;

public class DetailedAccountDTO
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public DateTime OpeningDate { get; set; }
    public CustomerDTO Customer { get; set; } = null!;

}
