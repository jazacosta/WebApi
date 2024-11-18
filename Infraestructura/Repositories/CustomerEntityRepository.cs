using Core.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class CustomerEntityRepository : ICustomerEntityRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerEntityRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}
