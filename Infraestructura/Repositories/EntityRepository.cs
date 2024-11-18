using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<EntityDTO> Create(CreateEntityRequest createEntityRequest)
        {
            var entity = createEntityRequest.Adapt<Entity>();

            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Adapt<EntityDTO>();
        }

        public async Task<EntityDTO> Update(UpdateEntityRequest request)
        {
            var entities = await VerifyExists(request.EntityId);
            request.Adapt(entities);
            await _context.SaveChangesAsync();
            return entities.Adapt<EntityDTO>();
        }

        public async Task<EntityDTO> Delete(int EntityId)
        {
            var entity = await VerifyExists(EntityId);

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return entity.Adapt<EntityDTO>();
        }

        private async Task<Entity> VerifyExists(int EntityId)
        {
            var entity = await _context.Entities.FindAsync(EntityId);
            if (entity == null) throw new Exception("The id entered does not match any user.");
            return entity;
        }
    }
}
