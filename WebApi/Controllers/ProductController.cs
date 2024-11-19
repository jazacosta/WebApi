using Core.DTOs.Product;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost("add/{EntityId}")]
    public async Task<IActionResult> Create(int EntityId, CreateProductDTO createProductDTO)
    {
        return Ok(await _productRepository.Create(EntityId, createProductDTO));
    }
}
