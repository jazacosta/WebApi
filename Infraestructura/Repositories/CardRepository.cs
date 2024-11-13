using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
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

    //1
    public async Task<CardDTO> Add(CreateCardDTO createCardDTO)
    {
        var entity = new Card
        {
            CustomerId = createCardDTO.CustomerId,
            //Type = createCardDTO.Type,
            //CreditLimit = createCardDTO.CreditLimit,
            ExpirationDate = createCardDTO.ExpirationDate,
            //InterestRate = createCardDTO.InterestRate,
            Number = createCardDTO.Number,
            Status = createCardDTO.Status,
            //AvailableCredit = createCardDTO.AvailableCredit
        };

        _context.Cards.Add(entity);
        await _context.SaveChangesAsync(); //this impacts the database

        //return AddTo(entity);
        return entity.Adapt<CardDTO>();

    }
    
    //2
    public async Task<CardDTO> Get(int CardId)
    {
        var entity = await _context.Cards
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.CardId == CardId);
        if (entity == null) 
            throw new Exception("The id entered does not match any card.");
        
        return entity.Adapt<CardDTO>();

        /*return new CardDTO
        {
            CardId = entity.CardId,
            CustomerId = entity.CustomerId,
            Number = entity.Number,
            ExpirationDate = entity.ExpirationDate,
            Status = entity.Status,
            CreditLimit = entity.CreditLimit,
            AvailableCredit = entity.AvailableCredit,
            InterestRate = entity.InterestRate
            //Customer = new CustomerDTO
            //{
            //    Id = entity.CustomerId
            //}
        };*/

    }

    //3
    public async Task<List<DetailedCardDTO>> GetAll(int customerId)
    {
        var entity = await _context.Customers
            .Include(x => x.Cards)
            .FirstOrDefaultAsync(x => x.Id == customerId);
         
        if (entity == null) throw new Exception("Client not found");

        return entity.Cards.Adapt<List<DetailedCardDTO>>();
    }

    private async Task<Card> VerifyExists(int CardId)
    {
        var entity = await _context.Cards.FindAsync(CardId);
        if (entity == null) throw new Exception("The id entered does not match any card.");
        return entity;
    }

    //String.Join
    
}
