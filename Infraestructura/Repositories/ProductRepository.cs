using Core.DTOs.Product;
using Core.Entities;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DetailedProductDTO> Create(int EntityId, CreateProductDTO createProductDTO)
    {
        var entity = createProductDTO.Adapt<Product>();
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Adapt<DetailedProductDTO>();
    }

    public async Task<Product> VerifyExist(int EntityId)
    {
        var entity = await _context.Products.FindAsync(EntityId);
        if (entity == null) throw new Exception("The id entered does not match any user.");
        return entity;
    }
}
