namespace Core.DTOs.Card;

public class CreateCardDTO
{
    public int CardId { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int CreditLimit { get; set; }
    public DateTime ExpirationDate { get; set; }
    public float InterestRate { get; set; }
    public int AvailableCredit { get; set; }

    public int CustomerId { get; set; }
    public string Status { get; set; } = string.Empty;

}
