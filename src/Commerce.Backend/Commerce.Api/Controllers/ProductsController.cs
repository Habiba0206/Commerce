using Commerce.Api.Common;
using Commerce.Application.Common.Services;
using Commerce.Application.Products.Commands;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all products with optional filtering and pagination.
    /// </summary>
    /// <param name="productGetQuery">Filtering and pagination options.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of products or 204 No Content if none found.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProductGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] ProductGetQuery productGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(productGetQuery, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The product if found, otherwise 404 Not Found.</returns>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<ProductGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid productId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new ProductGetByIdQuery { ProductId = productId }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">Product creation command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created product or 400 Bad Request if creation failed.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] ProductCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="command">Product update command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated product.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ProductGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] ProductUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates an existing product.
    /// </summary>
    /// <param name="command">Patch command with updated fields.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The patched product.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(ProductPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] ProductPatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="productId">The ID of the product to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 OK if deleted; otherwise 400 Bad Request.</returns>
    [HttpDelete("{productId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid productId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new ProductDeleteByIdCommand { ProductId = productId }, cancellationToken);
        return result ? Ok() : BadRequest();
    }

    /// <summary>
    /// Soft-deletes multiple entities by their IDs.
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteByIdsCommand"/> containing a list of entity IDs to be deleted.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token to cancel the operation if needed.
    /// </param>
    /// <remarks>
    /// This endpoint performs a soft delete by setting <c>IsDeleted = true</c> for each entity.
    /// </remarks>
    /// <response code="200">
    /// The entities were successfully marked as deleted.
    /// </response>
    /// <response code="400">
    /// One or more IDs were invalid or missing.
    /// </response>
    [HttpDelete("batch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteMany(
        [FromBody] ProductDeleteManyCommand command,
        CancellationToken ct = default)
    {
        var deletedCount = await mediator.Send(command, ct);
        return Ok(deletedCount);            
    }

    /// <summary>
    /// Uploads a preview image for a product and returns the file URL.
    /// </summary>
    /// <param name="uploadService">The file upload service (injected).</param>
    /// <param name="dto">The dto model where there is file to upload.</param>
    /// <returns>A URL pointing to the uploaded image.</returns>
    /// <response code="200">File uploaded successfully</response>
    /// <response code="400">No file was uploaded or file is empty</response>
    /// <response code="500">An unexpected error occurred while uploading</response>
    [HttpPost("upload-preview")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> UploadPreview([FromServices] IFileUploadService uploadService, [FromForm] ProductImageDto dto)
    {
        if (dto.File == null || dto.File.Length == 0)
            return BadRequest("No file uploaded.");

        var url = await uploadService.UploadImageAsync(dto.File);
        return Ok(new { url });
    }
}