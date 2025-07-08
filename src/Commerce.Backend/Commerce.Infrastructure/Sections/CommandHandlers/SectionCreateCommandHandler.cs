using AutoMapper;
using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Commands;
using Commerce.Domain.Entities;
using Commerce.Domain.Enums;
using Commerce.Infrastructure.Sections.Validators;
using FluentValidation;

namespace Commerce.Infrastructure.Sections.CommandHandlers;

public class SectionCreateCommandHandler(
    IMapper mapper,
    ISectionService service,
    SectionValidator validator) : ICommandHandler<SectionCreateCommand, SectionCreateUpdateDto>
{
    public async Task<SectionCreateUpdateDto> Handle(SectionCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(
            request.SectionCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var entity = mapper.Map<Section>(request.SectionCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<SectionCreateUpdateDto>(created);
    }
}
