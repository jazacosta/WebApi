using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly ApplicationDbContext _context;

    public ChargeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChargeDTO> Add(CreateChargeDTO createChargeDTO)
    {
        var entity = new Charge
        {
            CardId = createChargeDTO.CardId,
            Amount = createChargeDTO.Amount,
            AvailableCredit = createChargeDTO.AvailableCredit,
            Description = createChargeDTO.Description,
            Date = createChargeDTO.Date
        };

        _context.Charges.Add(entity);
        await _context.SaveChangesAsync();

        var dtos = new ChargeDTO()
        {
            ChargeId = entity.ChargeId,
            CardId = entity.CardId,
            Amount = entity.Amount,
            AvailableCredit = entity.AvailableCredit,
            Description = entity.Description,
            Date = entity.Date
        };

        return dtos;
    }
}
