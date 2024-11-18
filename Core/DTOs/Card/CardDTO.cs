namespace Core.DTOs.Card;

public class CardDTO
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    //public CustomerDTO Customer { get; set; } = null!;
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int CreditLimit { get; set; }
    public int AvailableCredit { get; set; }
    public float InterestRate { get; set; }
}
