using AutoMapper;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Queries;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Sections.QueryHandlers;

public class SectionGetQueryHandler(
    IMapper mapper,
    ISectionService service,
    GetQueryValidator validationRules)
    : IQueryHandler<SectionGetQuery, ICollection<SectionGetDto>>
{
    public async Task<ICollection<SectionGetDto>> Handle(SectionGetQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.SectionFilter ?? new SectionFilter();
        var validationResult = await validationRules.ValidateAsync(pagination);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await service.Get(
            request.SectionFilter,
            new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<SectionGetDto>>(result);
    }
}