using Commerce.Application.Manufacturers.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Manufacturers.Validators;

public class ProductManufacturerValidator : AbstractValidator<ProductManufacturerCreateUpdateDto>
{
    public ProductManufacturerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Manufacturer name is required.");
    }
}