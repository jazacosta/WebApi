namespace Core.DTOs;

public class DetailedCardDTO
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public int CreditLimit { get; set; }
    public int AvailableCredit { get; set; }

}
