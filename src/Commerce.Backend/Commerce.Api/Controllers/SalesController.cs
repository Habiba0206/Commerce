using Commerce.Api.Common;
using Commerce.Application.Sales.Commands;
using Commerce.Application.Sales.Models;
using Commerce.Application.Sales.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SalesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all sales with optional filtering and pagination.
    /// </summary>
    /// <param name="query">Sale filter and pagination query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of sales or 204 if none found.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<SaleGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] SaleGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Gets a sale record by ID.
    /// </summary>
    /// <param name="saleId">Sale identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Sale record or 404 if not found.</returns>
    [HttpGet("{saleId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<SaleGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid saleId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new SaleGetByIdQuery { SaleId = saleId }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new sale record.
    /// </summary>
    /// <param name="command">Sale creation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created sale record.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(SaleGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] SaleCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates a sale record.
    /// </summary>
    /// <param name="command">Update command with new data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated sale record.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(SaleGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] SaleUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates a sale record.
    /// </summary>
    /// <param name="command">Patch data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The patched record.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(SalePatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] SalePatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a sale record by ID.
    /// </summary>
    /// <param name="saleId">Sale ID to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 OK if deleted; 400 BadRequest if failed.</returns>
    [HttpDelete("{saleId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid saleId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new SaleDeleteByIdCommand { SaleId = saleId }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}