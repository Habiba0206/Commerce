using Commerce.Api.Common;
using Commerce.Application.Sections.Commands;
using Commerce.Application.Sections.Models;
using Commerce.Application.Sections.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SectionsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all sections with optional filtering and pagination.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<SectionGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] SectionGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a section by ID.
    /// </summary>
    [HttpGet("{sectionId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<SectionGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid sectionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new SectionGetByIdQuery { SectionId = sectionId }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new section.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(SectionGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] SectionCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing section.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(SectionGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] SectionUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates a section.
    /// </summary>
    [HttpPatch]
    [ProducesResponseType(typeof(SectionPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] SectionPatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a section by ID.
    /// </summary>
    [HttpDelete("{sectionId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid sectionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new SectionDeleteByIdCommand { SectionId = sectionId }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}
