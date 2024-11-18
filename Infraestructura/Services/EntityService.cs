using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;

namespace Infrastructure.Services;

public class EntityService : IEntityService
{
    private readonly IEntityRepository _repository;
    public EntityService(IEntityRepository repository)
    {
        _repository = repository;
    }

    public async Task<EntityDTO> Create(CreateEntityRequest request)
    {
        return await _repository.Create(request);
    }

    public Task<EntityDTO> Update(UpdateEntityRequest request)
    {
        throw new NotImplementedException();
    }
    public Task<EntityDTO> Delete(int EntityId)
    {
        throw new NotImplementedException();
    }

    //private async Task<Entity> VerifyExists(int EntityId)
    //{
    //    var entity = await _repository.Entities.FindAsync(EntityId);
    //    if (entity == null) throw new Exception("The id entered does not match any user.");
    //    return entity;
    //}
}
