using Commerce.Application.Categories.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Categories.Commands;

public record CategoryPatchCommand : ICommand<CategoryPatchDto>
{
    public CategoryPatchDto CategoryPatchDto { get; set; } = null!;
}
