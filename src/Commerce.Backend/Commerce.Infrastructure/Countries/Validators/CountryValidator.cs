using Commerce.Application.Countries.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Countries.Validators;

public class CountryValidator : AbstractValidator<CountryCreateUpdateDto>
{
    public CountryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Country name is required.");
    }
}