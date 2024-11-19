using Core.DTOs.Product;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task<ProductDTO> Create(int EntityId, CreateProductDTO createProductDTO);
}
