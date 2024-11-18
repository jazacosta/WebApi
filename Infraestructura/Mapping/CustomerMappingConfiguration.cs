using Core.DTOs.Account;
using Core.DTOs.Customer;
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
            
    }
}
