using Commerce.Application.Sales.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Sales.Validators;

public class SaleValidator : AbstractValidator<SaleCreateUpdateDto>
{
    public SaleValidator()
    {
        RuleFor(x => x.QuantitySold).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SaleDate).NotNull();
    }
}