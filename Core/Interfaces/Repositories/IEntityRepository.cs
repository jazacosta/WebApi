using Core.DTOs.Entity;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IEntityRepository
{
    Task<EntityDTO> Create(CreateEntityRequest request);
    Task<DetailedEntityDTO> GetEntitiesWithProducts(int Id);
    Task<EntityDTO> Update(UpdateEntityRequest request);
    Task<EntityDTO> Delete(int EntityId);
}
