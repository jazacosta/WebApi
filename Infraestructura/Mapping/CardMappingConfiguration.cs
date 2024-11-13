using Core.DTOs;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping;

public class CardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //1
        var random = new Random();
        config.NewConfig<Card, CreateCardDTO>()
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            //.Map(dest => dest.Type, src => src.Type)
            //.Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            //.Map(dest => dest.InterestRate, src => src.InterestRate)
            //
            .Map(dest => dest.Number, src => MaskCardNumber(src.Number))
            .Map(dest => dest.Status, src => "active");
            //.Map(dest => dest.AvailableCredit, src => random.Next(100, 10000));


        //2
        config.NewConfig<Card, CardDTO>()
            .Map(dest => dest.CardId, src => src.CardId)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.AvailableCredit, src => random.Next(100, 10000))
            .Map(dest => dest.Status, src => "active")
            //ver generador de 16 numeros de a 4 random
            .Map(dest => dest.Number, src => MaskCardNumber(src.Number));

        //3
        config.NewConfig<Card, DetailedCardDTO>()
            .Map(dest => dest.CardId, src => src.CardId)
            .Map(dest => dest.Number, src => MaskCardNumber(src.Number))
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit);
    }

    private string MaskCardNumber(string cardNumber)
    {
        if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
        {
            return cardNumber;
        }

        return new string('X', cardNumber.Length - 4) + cardNumber.Substring(cardNumber.Length - 4);
    }
}
