using Core.DTOs.Card;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateCardValidation : AbstractValidator<CreateCardDTO>
{
    public CreateCardValidation() 
    {
        RuleFor(create => create.Type)
            .NotEmpty()
            .Length(3, 40);
        RuleFor(create => create.CreditLimit)
            .NotEmpty()
            .NotNull()
            .WithMessage("The credit limit must be in a - range.");
        RuleFor(create => create.ExpirationDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("The expiration must be before the date 12/30/2029");
    }
}
