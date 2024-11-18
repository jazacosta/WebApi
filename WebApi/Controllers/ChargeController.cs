using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ChargeController : BaseApiController
    {
        // de más?
        //private readonly IChargeRepository _chargeRepository;
        //
        private readonly IValidator<CreateChargeDTO> _createChargeValidation;
        private readonly ICardService _cardService;

        public ChargeController(IValidator<CreateChargeDTO> createChargeValidation, ICardService cardService)
        {
            //_chargeRepository = chargeRepository;
            _createChargeValidation = createChargeValidation;
            _cardService = cardService;
        }

        [HttpPost("add/{CardId}")]
        public async Task<IActionResult> CreateCharge([FromRoute] int CardId, [FromBody] CreateChargeDTO createChargeDTO)
        {
            return Ok(await _cardService.CreateCharge(CardId, createChargeDTO));
        }
    }
}
