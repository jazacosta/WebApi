using Core.DTOs;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateValidation : AbstractValidator<CreateCustomerDTO>
{
    public CreateValidation()
    {
        RuleFor(create => create.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name can only contain letters, dots or spaces.")
            .Length(3, 40);

        RuleFor(create => create.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name can only contain letters, dots or spaces.")
            .Length(3, 40);

        RuleFor(create => create.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .WithMessage("The email must have an at symbol");

        RuleFor(create => create.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage("The phone number must have at least 10 numbers");

        RuleFor(create => create.BirthDate)
            .NotEmpty();
    }
}
