using Commerce.Application.Sales.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Infrastructure.Sales.Validators;

public class SaleCreateCommandValidator : AbstractValidator<SaleCreateCommand>
{
    public SaleCreateCommandValidator()
    {
        RuleFor(x => x.SaleCreateUpdateDto)
            .NotNull().WithMessage("SaleDto cannot be null.")
            .SetValidator(new SaleValidator());
    }
}