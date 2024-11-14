using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
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
        private readonly ICardService _service;

        public CardController(ICardRepository cardRepository, IValidator<CreateCardDTO> createCardValidation, ICardService cardService)
        {
            _cardRepository = cardRepository;
            _createCardValidation = createCardValidation;
            _service = cardService;
        }

        //1
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardDTO request)
        {
            return Ok(await _service.Create(request));
        }
        //[HttpPost("add")]
        //public async Task<IActionResult> Create([FromBody] CreateCardDTO createCardDTO)
        //{
        //    var result = await _createCardValidation.ValidateAsync(createCardDTO);
        //    if (!result.IsValid)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    return Ok(await _cardRepository.Create(createCardDTO));
        //}

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
