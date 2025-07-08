using Commerce.Application.Sections.Models;
using FluentValidation;

namespace Commerce.Infrastructure.Sections.Validators;

public class SectionValidator : AbstractValidator<SectionCreateUpdateDto>
{
    public SectionValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Section name is required.");
    }
}