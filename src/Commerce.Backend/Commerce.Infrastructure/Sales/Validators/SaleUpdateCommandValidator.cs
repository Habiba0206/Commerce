using Commerce.Application.Sales.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Infrastructure.Sales.Validators;

public class SaleUpdateCommandValidator : AbstractValidator<SaleUpdateCommand>
{
    public SaleUpdateCommandValidator()
    {
        RuleFor(x => x.SaleCreateUpdateDto)
            .NotNull().WithMessage("SaleDto cannot be null.")
            .SetValidator(new SaleValidator());
    }
}