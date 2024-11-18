using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly ApplicationDbContext _context;

    public ChargeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO createChargeDTO)
    {
        var card = await _context.Cards.FindAsync(CardId);

        var entity = createChargeDTO.Adapt<Charge>();
        entity.CardId = CardId; 
        entity.AvailableCredit = card!.AvailableCredit - createChargeDTO.Amount;

        card.AvailableCredit -= createChargeDTO.Amount;

        _context.Charges.Add(entity);

        await _context.SaveChangesAsync();
        return entity.Adapt<ChargeDTO>();
    }

    public async Task<bool> VerifyChargeAmount(int CardId, int Amount)
    {
        var card = await _context.Cards.FindAsync(CardId);
        if (card == null)
            throw new Exception("The card with the Id provided was not found");
        return card.CreditLimit >= Amount;
    }
}
