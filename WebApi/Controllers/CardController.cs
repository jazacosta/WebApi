using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("{CardId}")]
        public async Task<IActionResult> Get([FromRoute] int CardId)
        {
            return Ok(await _cardRepository.Get(CardId));
        }
    }
}
