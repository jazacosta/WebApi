using Core.DTOs.Entity;
using Core.DTOs.Payment;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mapping;

public class EntityMappingConfiguration
{
    //ENTITY
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entity, EntityDTO>();
        config.NewConfig<Entity, CreateEntityRequest>();
        config.NewConfig<Entity, UpdateEntityRequest>();

        config.NewConfig<Payment, PaymentDTO>();
        config.NewConfig<Payment, CreatePaymentDTO>();


    }
    //PRODUCT
}
