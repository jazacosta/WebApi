using Core.DTOs;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateChargeValidation : AbstractValidator<CreateChargeDTO>
{
    public CreateChargeValidation()
    {
        RuleFor(create => create.Amount)
            .NotEmpty()
            .NotNull()
            .WithMessage("The amount must be in a 1 - 500 range");
        RuleFor(create => create.Description)
            .NotEmpty()
            .NotNull();
        RuleFor(create => create.Date)
            .NotEmpty()
            .NotNull()
            .WithMessage("The date value is up to 12/30/2029");
    }
}