using Commerce.Application.Categories.Models;
using Commerce.Domain.Common.Commands;

namespace Commerce.Application.Categories.Commands;

public record CategoryCreateCommand : ICommand<CategoryCreateUpdateDto>
{
    public CategoryCreateUpdateDto CategoryCreateUpdateDto { get; set; }
}