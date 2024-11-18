using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{ 
    public class PaymentController : BaseApiController
    {
        //private readonly IPaymentRepository _paymentRepository;
        private readonly IValidator<CreatePaymentDTO> _createPaymentValidation;
        private readonly ICardService _cardService;
    
        public PaymentController(IValidator<CreatePaymentDTO> createPaymentValidator, ICardService cardService)
        {
            _createPaymentValidation = createPaymentValidator;
            _cardService = cardService;
        }
    
        [HttpPost("{CardId}/addPayment")]
        public async Task<IActionResult> AddPayment([FromRoute] int CardId, [FromBody] CreatePaymentDTO createPaymentDTO)
        {
            return Ok(await _cardService.CreatePayment(CardId, createPaymentDTO));
        }
    }
}