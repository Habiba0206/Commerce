using Commerce.Application.Products.Models;
using Commerce.Application.Statistics.Models;
using Commerce.Application.Statistics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StatisticsController(IStatisticsService stats) : ControllerBase
{
    /// <summary>
    /// Gets the single best‑selling product across the entire order history.
    /// </summary>
    /// <param name="ct">Request cancellation token.</param>
    /// <returns>
    /// 200&nbsp;OK &mdash; a <see cref="ProductGetDto"/> representing the product
    /// with the highest total quantity sold.<br/>
    /// 204&nbsp;No&nbsp;Content &mdash; if no sales exist.
    /// </returns>
    [HttpGet("best-seller")]
    [ProducesResponseType(typeof(ProductGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetBestSeller(CancellationToken ct = default)
    {
        var dto = await stats.GetBestSellingProductAsync(ct);
        return dto is null ? NoContent() : Ok(dto);
    }

    /// <summary>
    /// Gets the product that has accumulated the highest number of page views.
    /// </summary>
    /// <param name="ct">Request cancellation token.</param>
    [HttpGet("most-viewed")]
    [ProducesResponseType(typeof(ProductGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetMostViewed(CancellationToken ct = default)
    {
        var dto = await stats.GetMostViewedProductAsync(ct);
        return dto is null ? NoContent() : Ok(dto);
    }

    /// <summary>
    /// Counts products that are currently in stock (<c>Availability = true</c>).
    /// </summary>
    /// <param name="ct">Request cancellation token.</param>
    [HttpGet("items-on-sale")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<int> GetItemsOnSaleCount(CancellationToken ct = default) =>
        await stats.GetItemsOnSaleCountAsync(ct);

    /// <summary>
    /// Counts sales that occurred during the current calendar month (UTC).
    /// </summary>
    /// <param name="ct">Request cancellation token.</param>
    [HttpGet("sales-this-month")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<int> GetSalesThisMonthCount(CancellationToken ct = default) =>
        await stats.GetSalesThisMonthCountAsync(ct);

    // Shared XML for pagination params
    private const string PageParam = "pageToken (1‑based).";
    private const string SizeParam = "pageSize (number of items per page).";

    /// <summary>
    /// Paged list of products ordered by total quantity sold (descending).
    /// </summary>
    /// <param name="page">1‑based <inheritdoc cref="PageParam" path="/value"/></param>
    /// <param name="size"><inheritdoc cref="SizeParam" path="/value"/></param>
    /// <param name="ct">Cancellation token.</param>
    [HttpGet("top-selling-products")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductGetDto>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<ProductGetDto>> GetTopSellingProducts(
        [FromQuery] int page = 1,
        [FromQuery] int size = 8,
        CancellationToken ct = default) =>
        await stats.GetTopSellingProductsAsync(new(size, page), ct);

    /// <summary>
    /// Paged list of products ordered by the <c>Views</c> counter (descending).
    /// </summary>
    /// <param name="page"><inheritdoc cref="PageParam" path="/value"/></param>
    /// <param name="size"><inheritdoc cref="SizeParam" path="/value"/></param>
    /// <param name="ct">Cancellation token.</param>
    [HttpGet("top-viewed-products")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductGetDto>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<ProductGetDto>> GetTopViewedProducts(
        [FromQuery] int page = 1,
        [FromQuery] int size = 8,
        CancellationToken ct = default) =>
        await stats.GetTopViewedProductsAsync(new(size, page), ct);

    /// <summary>
    /// Paged list of sections ranked by total profit
    /// (<c>Σ&nbsp;Profit × Amount</c> of products in that section).
    /// </summary>
    /// <param name="page"><inheritdoc cref="PageParam" path="/value"/></param>
    /// <param name="size"><inheritdoc cref="SizeParam" path="/value"/></param>
    /// <param name="ct">Cancellation token.</param>
    [HttpGet("top-sections")]
    [ProducesResponseType(typeof(IReadOnlyList<SectionStat>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<SectionStat>> GetTopSections(
        [FromQuery] int page = 1,
        [FromQuery] int size = 7,
        CancellationToken ct = default) =>
        await stats.GetTopSectionsAsync(new(size, page), ct);

    /// <summary>
    /// Paged list of categories ranked by total profit.
    /// </summary>
    /// <param name="page"><inheritdoc cref="PageParam" path="/value"/></param>
    /// <param name="size"><inheritdoc cref="SizeParam" path="/value"/></param>
    /// <param name="ct">Cancellation token.</param>
    [HttpGet("top-categories")]
    [ProducesResponseType(typeof(IReadOnlyList<CategoryStat>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyList<CategoryStat>> GetTopCategories(
        [FromQuery] int page = 1,
        [FromQuery] int size = 7,
        CancellationToken ct = default) =>
        await stats.GetTopCategoriesAsync(new(size, page), ct);
}