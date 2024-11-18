using Core.DTOs.Payment;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO createPaymentDTO);

    Task<bool> VerifyPaymentAmount(int CardId, int Amount);
}
