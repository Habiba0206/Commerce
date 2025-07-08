using Commerce.Application.Sections.Commands;
using FluentValidation;

namespace Commerce.Infrastructure.Sections.Validators;

public class SectionPatchCommandValidator : AbstractValidator<SectionPatchCommand>
{
    public SectionPatchCommandValidator()
    {
        RuleFor(x => x.SectionPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.SectionPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}