using Core.DTOs;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ChargeController : BaseApiController
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly IValidator<CreateChargeDTO> _createChargeValidation;

        public ChargeController(IChargeRepository chargeRepository, IValidator<CreateChargeDTO> createChargeValidation)
        {
            _chargeRepository = chargeRepository;
            _createChargeValidation = createChargeValidation;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateChargeDTO createChargeDTO)
        {
            var result = await _createChargeValidation.ValidateAsync(createChargeDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _chargeRepository.Add(createChargeDTO));
        }
    }
}
