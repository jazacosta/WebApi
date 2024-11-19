using Core.DTOs.Entity;
using Core.DTOs.Payment;
using Core.DTOs.Product;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mapping;

public class EntityMappingConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        //ENTITY
        config.NewConfig<Entity, EntityDTO>();
        config.NewConfig<Entity, CreateEntityRequest>();
        config.NewConfig<Entity, UpdateEntityRequest>();
        config.NewConfig<Entity, EntityProductDTO>();

        //PRODUCT
        config.NewConfig<Product, ProductDTO>()
        .Map(dest => dest.Date, src => src.Date.ToShortDateString());

        config.NewConfig<Product, CreateProductDTO>()
        .Map(dest => dest.Date, src => src.Date.ToShortDateString());

        config.NewConfig<Product, CustomerProductDTO>();

    }
}
