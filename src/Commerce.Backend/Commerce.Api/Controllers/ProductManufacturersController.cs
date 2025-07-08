using Commerce.Api.Common;
using Commerce.Application.Manufacturers.Commands;
using Commerce.Application.Manufacturers.Models;
using Commerce.Application.Manufacturers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductManufacturersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all product manufacturers.
    /// </summary>
    /// <param name="query">Filter and pagination options.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of manufacturers or 204 No Content.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProductManufacturerGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] ProductManufacturerGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a manufacturer by ID.
    /// </summary>
    /// <param name="manufacturerId">ID of the manufacturer.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The manufacturer if found, otherwise NotFound.</returns>
    [HttpGet("{manufacturerId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<ProductManufacturerGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid manufacturerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new ProductManufacturerGetByIdQuery { ProductManufacturerId = manufacturerId }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new manufacturer.
    /// </summary>
    /// <param name="command">Creation command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created manufacturer or BadRequest.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductManufacturerGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] ProductManufacturerCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing manufacturer.
    /// </summary>
    /// <param name="command">Update command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated manufacturer.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ProductManufacturerGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] ProductManufacturerUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates a manufacturer.
    /// </summary>
    /// <param name="command">Patch command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Patched result.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(ProductManufacturerPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] ProductManufacturerPatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a manufacturer by ID.
    /// </summary>
    /// <param name="manufacturerId">ID of the manufacturer.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 OK or 400 BadRequest.</returns>
    [HttpDelete("{manufacturerId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid manufacturerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new ProductManufacturerDeleteByIdCommand { ProductManufacturerId = manufacturerId }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}
