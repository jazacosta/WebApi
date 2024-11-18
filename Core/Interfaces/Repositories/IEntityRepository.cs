using Core.DTOs.Entity;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IEntityRepository
{
    Task<EntityDTO> Create(CreateEntityRequest request);
    //Task<List<EntityDTO>> GetAll();
    Task<EntityDTO> Update(UpdateEntityRequest request);
    Task<EntityDTO> Delete(int EntityId);
}
