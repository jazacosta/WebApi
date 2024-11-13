namespace Core.DTOs;

public class CreateChargeDTO
{
    public int CardId { get; set; }
    public int Amount { get; set; }
    public int AvailableCredit { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
