using Core.DTOs.Account;
using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Infrastructure.Configuration;
using Mapster;

namespace Infrastructure.Mapping;

public class CustomerMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.BirthDate, src => src.BirthDate)
            .Map(dest => dest.Accounts, src => src.Accounts.Select(x => x.Adapt<DetailedAccountDTO>()));

        config.NewConfig<Customer, CustomerProductDTO>()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.Products, src => src.CustomerEntities);

        config.NewConfig<CustomerEntity, EntityProductDTO>()
            .Map(dest => dest.EntityName, src => src.Entity.Name)
            .Map(dest => dest.Products, src => src.CustomerEntityProducts);

        config.NewConfig<CustomerEntityProduct, ProductDTO>()
            .Map(dest => dest.ProductId, src => src.Products.ProductId) //verificar
            .Map(dest => dest.Name, src => src.Products.Name);
    }
}
