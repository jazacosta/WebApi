namespace Core.DTOs;

public class CreateCardDTO
{
    public int CustomerId { get; set; }
    public string Type { get; set; } = string.Empty;
    public int CreditLimit { get; set; }
    public DateTime ExpirationDate  { get; set; }
    public float InterestRate { get; set; }
    //
    public string Number { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    //public int AvailableCredit { get; set; }

}
