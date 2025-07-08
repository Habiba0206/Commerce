using Commerce.Application.Products.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Products.Validators;

public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
{
    public ProductCreateCommandValidator()
    {
        RuleFor(x => x.ProductCreateUpdateDto)
            .NotNull().WithMessage("ProductDto cannot be null.")
            .SetValidator(new ProductValidator());
    }
}