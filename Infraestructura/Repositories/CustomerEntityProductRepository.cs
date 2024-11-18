using Core.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class CustomerEntityProductRepository : ICustomerEntityProduct
{
    private readonly ApplicationDbContext _context;

    public CustomerEntityProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}
