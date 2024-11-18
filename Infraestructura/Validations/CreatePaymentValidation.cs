using Core.DTOs.Payment;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreatePaymentValidation : AbstractValidator<CreatePaymentDTO>
{
    public CreatePaymentValidation()
    {
        RuleFor(create => create.Amount)
            .NotEmpty()
            .NotNull()
            .WithMessage("The amount must be in a 1 - 500 range");
        RuleFor(create => create.PaymentMethod)
            .NotEmpty()
            .NotNull()
            .WithMessage("You must specify the payment method");
        RuleFor(create => create.Date)
            .NotEmpty()
            .NotNull()
            .WithMessage("The date value is up to 12/30/2029");
    }
}
