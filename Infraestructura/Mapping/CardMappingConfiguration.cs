using Core.DTOs;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping;

public class CardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Card, CardDTO>()
            .Map(dest => dest.CardId, src => src.CardId)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.InterestRate, src => src.InterestRate);

    }
}
