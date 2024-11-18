using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Payment;

namespace Core.Interfaces.Services;

public interface ICardService
{
    Task<CardDTO> Create(CreateCardDTO request);
    Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO request);
    Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO createPaymentDTO);
}
