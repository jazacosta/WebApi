using Core.DTOs.Product;
using Core.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<DetailedProductDTO> Create(int EntityId, CreateProductDTO createProductDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> VerifyExist(int EntityId)
    {
        var entity = await _context.Products.FindAsync(EntityId);
        if (entity == null) throw new Exception("The id entered does not match any user.");
        return entity;
    }
}
