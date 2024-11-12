﻿using Core.DTOs;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateCardValidation : AbstractValidator<CreateCardDTO>
{
    public CreateCardValidation() 
    {
        RuleFor(create => create.Type)
            .NotEmpty()
            //.WithMessage("")
            .Length(3, 40);
        RuleFor(create => create.CreditLimit)
            .NotEmpty()
            .NotNull()
            .WithMessage("The credit limit must be in a - range.");
        RuleFor(create => create.ExpirationDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("The expiration must be before the date 12/30/2029 (dd/mm/yyyy)");
    }
}
