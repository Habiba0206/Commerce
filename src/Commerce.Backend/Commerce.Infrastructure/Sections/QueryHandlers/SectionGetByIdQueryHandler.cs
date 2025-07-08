using AutoMapper;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Queries;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Queries;

namespace Commerce.Infrastructure.Sections.QueryHandlers;

public class SectionGetByIdQueryHandler(
    IMapper mapper,
    ISectionService service)
    : IQueryHandler<SectionGetByIdQuery, SectionGetDto>
{
    public async Task<SectionGetDto> Handle(SectionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(request.SectionId, cancellationToken: cancellationToken);
        return mapper.Map<SectionGetDto>(result);
    }
}