namespace Core.Entities;

public class Card
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int CreditLimit { get; set; }
    public int AvailableCredit {  get; set; }
    public float InterestRate { get; set; }

    public Customer Customer { get; set; } = null!;
    public List<Charge> Charges { get; set; } = [];
    //public List<Payment> Payments { get; set; } = [];
}
