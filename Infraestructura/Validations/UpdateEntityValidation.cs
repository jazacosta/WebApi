using Core.Requests;
using FluentValidation;

namespace Infrastructure.Validations;

public class UpdateEntityValidation : AbstractValidator<UpdateEntityRequest>
{
    public UpdateEntityValidation()
    {
        RuleFor(create => create.Name)
            .NotEmpty()
            .NotNull()
            .Length(2, 50);
        RuleFor(create => create.Description)
            .NotEmpty()
            .NotNull()
            .Length(10, 200);
        RuleFor(create => create.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("The ID of Costumer must be a number under 1000");
    }
}
