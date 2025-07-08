using AutoMapper;
using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Sections.CommandHandlers;

public class SectionPatchCommandHandler(
    ISectionService service,
    IMapper mapper)
    : ICommandHandler<SectionPatchCommand, SectionPatchDto>
{
    public async Task<SectionPatchDto> Handle(SectionPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.SectionPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<SectionPatchDto>(entity);
    }
}