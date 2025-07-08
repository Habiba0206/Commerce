using Commerce.Application.Manufacturers.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Manufacturers.Validators;

public class ProductManufacturerCreateCommandValidator : AbstractValidator<ProductManufacturerCreateCommand>
{
    public ProductManufacturerCreateCommandValidator()
    {
        RuleFor(x => x.ProductManufacturerCreateUpdateDto)
            .NotNull().WithMessage("ProductManufacturerDto cannot be null.")
            .SetValidator(new ProductManufacturerValidator());
    }
}