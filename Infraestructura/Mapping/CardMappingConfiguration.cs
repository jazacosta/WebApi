using Core.DTOs;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping;

public class CardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //CARD
        //1
        //var random = new Random();
        config.NewConfig<Card, CreateCardDTO>()
            .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4),4}");
            /*//.Map(dest => dest.Number, src => GetCardNumber())
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            //.Map(dest => dest.AvailableCredit, src => random.Next(100, 10000))
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.CustomerId, src => src.CustomerId);
        //
        //.Map(dest => dest.Status, src => "active");
            */


        //2
        config.NewConfig<Card, CardDTO>()
            /*.Map(dest => dest.CardId, src => src.CardId)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.Status, src => "active")
            //ver generador de 16 numeros de a 4 random*/
            .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4),4}");

        //3
        config.NewConfig<Card, DetailedCardDTO>()
            .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4),4}");

        /*.Map(dest => dest.CardId, src => src.CardId)
        .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
        .Map(dest => dest.CreditLimit, src => src.CreditLimit)
        .Map(dest => dest.AvailableCredit, src => src.AvailableCredit);*/


        //CHARGE
        config.NewConfig<Charge, ChargeDTO>();
        config.NewConfig<Charge, CreateChargeDTO>();
    }

    public static string GetCardNumber()
    {
        var random = new Random();
        List<string> CardNumber = [];
        for (int i = 0; i < 4; i++)
        {
            CardNumber.Add(random.Next(1000, 10000).ToString());
        }
        return String.Join('-', CardNumber);
    }
}
