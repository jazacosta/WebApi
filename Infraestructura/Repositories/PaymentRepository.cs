using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentDTO> CreatePayment(int CardId, CreatePaymentDTO createPaymentDTO)
    {
        var card = await _context.Cards.FindAsync(CardId);

        var entity = createPaymentDTO.Adapt<Payment>();
        entity.CardId = CardId;
        entity.AvailableCredit = card!.AvailableCredit + createPaymentDTO.Amount;

        card.AvailableCredit += createPaymentDTO.Amount;

        _context.Payments.Add(entity);

        await _context.SaveChangesAsync();
        return entity.Adapt<PaymentDTO>();
    }

    public async Task<bool> VerifyPaymentAmount(int CardId, int Amount)
    {
        var card = await _context.Cards.FindAsync(CardId);
        if (card == null)
            throw new Exception("The card with the Id provided was not found");
        return card.CreditLimit >= (card.AvailableCredit + Amount);
    }
}
