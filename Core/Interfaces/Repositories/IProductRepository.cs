using Core.DTOs.Product;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task<DetailedProductDTO> Create(int EntityId, CreateProductDTO createProductDTO);
    //Task<bool> VerifyExist(int EntityId);
}
