using Commerce.Application.Products.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Products.Validators;

public class ProductFilterValidator : AbstractValidator<ProductFilter>
{
    public ProductFilterValidator()
    {
        RuleFor(f => f.MinimumPrice).GreaterThanOrEqualTo(0).When(f => f.MinimumPrice.HasValue);
        RuleFor(f => f.MaximumPrice).GreaterThan(0).When(f => f.MaximumPrice.HasValue);
        RuleFor(f => f).Must(f =>
            !f.MinimumPrice.HasValue || !f.MaximumPrice.HasValue ||
            f.MinimumPrice <= f.MaximumPrice).WithMessage("MinimumPrice must be ≤ MaximumPrice");
    }
}