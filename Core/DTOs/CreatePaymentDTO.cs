namespace Core.DTOs;

public class CreatePaymentDTO
{
    public int CardId { get; set; }
    public int Amount { get; set; }
    public int AvailableCredit { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
