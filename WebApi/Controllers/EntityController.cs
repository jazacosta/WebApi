using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Requests;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EntityController : BaseApiController
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IValidator<CreateEntityRequest> _createEntityValidation;
        private readonly IValidator<UpdateEntityRequest> _updateEntityValidation;
        public EntityController(IEntityRepository entityRepository, IValidator<CreateEntityRequest> createEntityRequest, IValidator<UpdateEntityRequest> updateEntityRequest)
        {
            _entityRepository = entityRepository;
            _createEntityValidation = createEntityRequest;
            _updateEntityValidation = updateEntityRequest;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateEntityRequest createEntityRequest)
        {
            var result = await _createEntityValidation.ValidateAsync(createEntityRequest);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _entityRepository.Create(createEntityRequest));
        }

        //[HttpGet("getAll/entitiesWithProducts/{Id}")]
        //public async Task<IActionResult> GetEntitiesWithProducts([FromRoute] int Id)
        //{
        //    return Ok(await _entityRepository.GetEntitiesWithProducts(Id));
        //}
        //validate!!

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateEntityRequest updateEntityRequest)
        {
            var result = await _updateEntityValidation.ValidateAsync(updateEntityRequest);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _entityRepository.Update(updateEntityRequest));
        }

        [HttpDelete("delete/{EntityId}")]
        public async Task<IActionResult> Delete([FromRoute] int EntityId)
        {
            return Ok(await _entityRepository.Delete(EntityId));
        }


    }
}
