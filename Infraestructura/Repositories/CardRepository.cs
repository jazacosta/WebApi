using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace Infrastructure.Repositories;

public class CardRepository : ICardRepository
{
    private readonly ApplicationDbContext _context;

    public CardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CardDTO> Get(int CardId)
    {
        var entity = await _context.Cards
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.CardId == CardId);
        if (entity == null) 
            throw new Exception("The id entered does not match any card.");

        return new CardDTO
        {
            CardId = entity.CardId,
            CustomerId = entity.CustomerId,
            Number = entity.Number,
            ExpirationDate = entity.ExpirationDate,
            Status = entity.Status,
            CreditLimit = entity.CreditLimit,
            AvailableCredit = entity.AvailableCredit,
            InterestRate = entity.InterestRate
            /*Customer = new CustomerDTO
            {
                Id = entity.CustomerId
            }*/
        };
    }



    private async Task<Card> VerifyExists(int CardId)
    {
        var entity = await _context.Cards.FindAsync(CardId);
        if (entity == null) throw new Exception("The id entered does not match any card.");
        return entity;
    }
}
