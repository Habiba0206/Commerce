using Commerce.Api.Common;
using Commerce.Application.Categories.Commands;
using Commerce.Application.Categories.Models;
using Commerce.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

/// <summary>
/// Handles operations related to categories including retrieving, creating,
/// updating, patching, and deleting.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all categories with optional filtering and pagination.
    /// </summary>
    /// <param name="query">The category get query including filters.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>List of categories or NoContent if empty.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<CategoryGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] CategoryGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a specific category by ID.
    /// </summary>
    /// <param name="categoryId">The unique ID of the category.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The category data if found; otherwise NotFound.</returns>
    [HttpGet("{categoryId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<CategoryGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid categoryId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CategoryGetByIdQuery { CategoryId = categoryId }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="command">The creation command with necessary data.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The created category or BadRequest if failed.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] CategoryCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="command">The update command with the modified category data.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The updated category.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(CategoryGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] CategoryUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Applies partial updates to an existing category.
    /// </summary>
    /// <param name="command">The patch command with updated fields.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The patched category.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(CategoryPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] CategoryPatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category to delete.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>200 OK if deleted; otherwise BadRequest.</returns>
    [HttpDelete("{categoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid categoryId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CategoryDeleteByIdCommand { CategoryId = categoryId }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}