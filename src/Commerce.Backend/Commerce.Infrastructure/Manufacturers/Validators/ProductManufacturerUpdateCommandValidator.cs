using Commerce.Application.Manufacturers.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Manufacturers.Validators;

public class ProductManufacturerUpdateCommandValidator : AbstractValidator<ProductManufacturerUpdateCommand>
{
    public ProductManufacturerUpdateCommandValidator()
    {
        RuleFor(x => x.ProductManufacturerCreateUpdateDto)
            .NotNull().WithMessage("ProductManufacturerDto cannot be null.")
            .SetValidator(new ProductManufacturerValidator());
    }
}