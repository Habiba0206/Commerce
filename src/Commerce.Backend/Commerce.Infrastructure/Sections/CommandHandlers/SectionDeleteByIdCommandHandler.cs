using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Sections.CommandHandlers;

public class SectionDeleteByIdCommandHandler(
    ISectionService service)
    : ICommandHandler<SectionDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(SectionDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.SectionId, cancellationToken: cancellationToken);
        return result is not null;
    }
}