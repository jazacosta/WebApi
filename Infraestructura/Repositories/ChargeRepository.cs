using Core.DTOs;
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

    public async Task<ChargeDTO> CreateCharge(CreateChargeDTO createChargeDTO)
    {
        var entity = createChargeDTO.Adapt<Charge>();
        var card = await _context.Cards.FindAsync(createChargeDTO.CardId);
        entity.AvailableCredit = card!.AvailableCredit - createChargeDTO.Amount;
        card!.AvailableCredit -= createChargeDTO.Amount;

        _context.Charges.Add(entity);

        await _context.SaveChangesAsync();
        return entity.Adapt<ChargeDTO>();
    }

    public async Task<bool> VerifyChargeAmount(int CardId, int Amount)
    {
        var card = await _context.Cards.FindAsync(CardId);
        return card == null
            ? throw new Exception("The card with Id provided was not found")
            : card.CreditLimit - card.AvailableCredit >= Amount;
    }
}
