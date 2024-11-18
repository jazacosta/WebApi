using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _repository;
    private readonly IChargeRepository _chargeRepository;
    private readonly IPaymentRepository _paymentRepository;

    public CardService(ICardRepository repository, IChargeRepository chargeRepository, IPaymentRepository paymentRepository)
    {
        _repository = repository;
        _chargeRepository = chargeRepository;
        _paymentRepository = paymentRepository;
    }

    public async Task<CardDTO> Create(CreateCardDTO request)
    {
        return await _repository.Create(request);
    }

    public async Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO request)
    {
        var isTransactionAllowed = await _chargeRepository.VerifyChargeAmount(CardId, request.Amount);
        if (!isTransactionAllowed)
            throw new Exception("The amount surpasses the limit");
        return await _chargeRepository.CreateCharge(CardId, request);
    }

    public async Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO request)
    {
        var isTransactionAllowed = await _paymentRepository.VerifyPaymentAmount(CardId, request.Amount);
        if (!isTransactionAllowed)
            throw new Exception("The amount surpasses the limit");
        return await _paymentRepository.CreatePayment(CardId, request);
    }
}
