using Commerce.Application.Countries.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Countries.Validators;

public class CountryCreateCommandValidator : AbstractValidator<CountryCreateCommand>
{
    public CountryCreateCommandValidator()
    {
        RuleFor(x => x.CountryCreateUpdateDto)
            .NotNull().WithMessage("CountryDto cannot be null.")
            .SetValidator(new CountryValidator());
    }
}