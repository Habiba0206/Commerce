using Commerce.Application.Products.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Products.Validators;

public class ProductValidator : AbstractValidator<ProductCreateUpdateDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.MetaTitle)
            .NotEmpty().WithMessage("Meta title is required.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required.");

        RuleFor(x => x.IdentificationNumber)
            .NotEmpty().WithMessage("Identification number is required.");

        RuleFor(x => x.Priority)
            .GreaterThanOrEqualTo(0).WithMessage("Priority must be non-negative.");

        RuleFor(x => x.Link)
            .NotEmpty().WithMessage("Link is required.")
            .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _)).WithMessage("Link must be a valid URL.");

        RuleFor(x => x.MetaTags)
            .NotEmpty().WithMessage("Meta tags are required.");

        RuleFor(x => x.MetaDescription)
            .NotEmpty().WithMessage("Meta description is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.Extra)
            .InclusiveBetween(1, 100).WithMessage("Extra must be between 1 and 100.");

        RuleFor(x => x.Profit)
            .GreaterThanOrEqualTo(0).WithMessage("Profit must be non-negative.");

        RuleFor(x => x.Warehouse)
            .NotEmpty().WithMessage("Warehouse is required.");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0).WithMessage("Amount must be non-negative.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Image URL must be valid.");

        RuleFor(x => x.Views)
            .GreaterThanOrEqualTo(0).WithMessage("Views must be non-negative.");

        RuleFor(x => x.ProductManufacturerId)
            .NotEqual(Guid.Empty).WithMessage("Product manufacturer ID must be provided.");

        RuleFor(x => x.SectionId)
            .NotEqual(Guid.Empty).WithMessage("Section ID must be provided.");

        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).WithMessage("Category ID must be provided.");

        RuleFor(x => x.CountryId)
            .NotEqual(Guid.Empty).WithMessage("Country ID must be provided.");
    }
}