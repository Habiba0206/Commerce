using Commerce.Application.Categories.Commands;
using Commerce.Application.Categories.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Categories.CommandHandlers;

public class CategoryDeleteByIdCommandHandler(
    ICategoryService service)
    : ICommandHandler<CategoryDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CategoryDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.CategoryId, cancellationToken: cancellationToken);
        return result is not null;
    }
}