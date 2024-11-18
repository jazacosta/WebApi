using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping;

public class CardMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //CARD
        //1
        config.NewConfig<Card, CreateCardDTO>()
            .Map(dest => dest.Number, src => GetCardNumber())
            .Map(dest => dest.AvailableCredit, src => new Random().Next(0, (int)src.CreditLimit))
            .Map(dest => dest.Status, src => "active");


        //2
        config.NewConfig<Card, CardDTO>()
            .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4, 4)}");

        //3
        config.NewConfig<Card, DetailedCardDTO>()
            .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4, 4)}");


        //CHARGE
        config.NewConfig<Charge, ChargeDTO>()
        .Map(dest => dest.Date, src => src.Date.ToShortDateString());

        config.NewConfig<Charge, CreateChargeDTO>()
        .Map(dest => dest.Date, src => src.Date.ToShortDateString());
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
