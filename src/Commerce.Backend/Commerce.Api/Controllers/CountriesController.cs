using Commerce.Api.Common;
using Commerce.Application.Countries.Commands;
using Commerce.Application.Countries.Models;
using Commerce.Application.Countries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CountriesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all countries with optional filtering and pagination.
    /// </summary>
    /// <param name="query">Filtering and pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of countries or 204 No Content.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<CountryGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] CountryGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a country by its ID.
    /// </summary>
    /// <param name="id">The country ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The country data or 404 if not found.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<CountryGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CountryGetByIdQuery { CountryId = id }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new country.
    /// </summary>
    /// <param name="command">The creation command with country details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created country or BadRequest if failed.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CountryGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] CountryCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing country.
    /// </summary>
    /// <param name="command">The update command with updated details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated country data.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(CountryGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] CountryUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Applies partial updates to a country.
    /// </summary>
    /// <param name="command">The patch command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The patched country data.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(CountryPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] CountryPatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a country by its ID.
    /// </summary>
    /// <param name="id">The country ID to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 OK if deleted, 400 if failed.</returns>
    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CountryDeleteByIdCommand { CountryId = id }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}