namespace Core.DTOs;

public class PaymentDTO
{
    public int PaymentId { get; set; }
    public int CardId { get; set; }
    public int Amount { get; set; }
    public int AvailableCredit { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
