using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _repository;
    private readonly IChargeRepository _chargeRepository;
    public CardService(ICardRepository repository, IChargeRepository chargeRepository)
    {
        _repository = repository;
        _chargeRepository = chargeRepository;
    }
    public async Task<CardDTO> Create(CreateCardDTO request)
    {
        return await _repository.Create(request);
    }
    public async Task<ChargeDTO> CreateCharge(CreateChargeDTO request)
    {
        var isTransactionAllowed = await _chargeRepository.VerifyChargeAmount(request.CardId, request.Amount);
        if (!isTransactionAllowed)
            throw new Exception("The amount surpass the limit");
        return await _chargeRepository.CreateCharge(request);
    }
}
