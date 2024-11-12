using Core.DTOs;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping
{
    public class AccountMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Account, DetailedAccountDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Number, src => src.Number)
                .Map(dest => dest.Balance, src => src.Balance)
                .Map(dest => dest.OpeningDate, src => src.OpeningDate)
                .Map(dest => dest.Customer, src => src.Customer);
                
        }
    }
}
