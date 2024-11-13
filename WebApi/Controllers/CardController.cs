using Core.DTOs;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly ICardRepository _cardRepository;
        private readonly IValidator<CreateCardDTO> _createCardValidation;

        public CardController(ICardRepository cardRepository, IValidator<CreateCardDTO> createCardValidation)
        {
            _cardRepository = cardRepository;
            _createCardValidation = createCardValidation;
        }

        //1
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCardDTO createCardDTO)
        {
            var result = await _createCardValidation.ValidateAsync(createCardDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _cardRepository.Add(createCardDTO));
        }

        //2
        [HttpGet("{CardId}")]
        public async Task<IActionResult> Get([FromRoute] int CardId)
        {
            return Ok(await _cardRepository.Get(CardId));
        }

        //3
        [HttpGet("/Customer/{customerId}/cards/getAll")]
        public async Task<List<DetailedCardDTO>> GetAll([FromRoute] int customerId)
        {
            return await _cardRepository.GetAll(customerId);
        }


    }
}
