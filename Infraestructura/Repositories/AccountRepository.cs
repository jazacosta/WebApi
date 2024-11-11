using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DetailedAccountDTO> GetById(int id)
    {
        var entity = await _context.Accounts
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new Exception("The id entered does not match any user.");
        }

        return new DetailedAccountDTO
        {
            Number = entity.Number,
            Balance = entity.Balance,
            OpeningDate = entity.OpeningDate,
            Customer = new CustomerDTO
            {
                Id = entity.Id,
                FullName = $"{entity.Customer.FirstName} {entity.Customer.LastName}",
                Email = entity.Customer.Email,
                Phone = entity.Customer.Phone,
                BirthDate = entity.Customer.BirthDate
            }
        };


    }
}
