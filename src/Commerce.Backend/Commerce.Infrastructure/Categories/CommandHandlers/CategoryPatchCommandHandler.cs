using AutoMapper;
using Commerce.Application.Categories.Commands;
using Commerce.Application.Categories.Models;
using Commerce.Application.Categories.Services;
using Commerce.Domain.Common.Commands;

namespace Commerce.Infrastructure.Categories.CommandHandlers;

public class CategoryPatchCommandHandler(
    ICategoryService service,
    IMapper mapper)
    : ICommandHandler<CategoryPatchCommand, CategoryPatchDto>
{
    public async Task<CategoryPatchDto> Handle(CategoryPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.CategoryPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<CategoryPatchDto>(entity);
    }
}