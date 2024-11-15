using Core.DTOs;
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

    }
    //PRODUCT
}
