using Core.DTOs.Entity;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IEntityService
{
    Task<EntityDTO> Create(CreateEntityRequest request);
    Task<EntityDTO> Update(UpdateEntityRequest request);
    Task<EntityDTO> Delete(int EntityId);


}
