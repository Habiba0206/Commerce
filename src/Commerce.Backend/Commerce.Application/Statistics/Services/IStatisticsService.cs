using Commerce.Application.Products.Models;
using Commerce.Application.Statistics.Models;
using Commerce.Domain.Common.Queries;

namespace Commerce.Application.Statistics.Services;

public interface IStatisticsService
{
    ValueTask<ProductGetDto?> GetBestSellingProductAsync(CancellationToken ct);
    ValueTask<ProductGetDto?> GetMostViewedProductAsync(CancellationToken ct);
    ValueTask<int> GetItemsOnSaleCountAsync(CancellationToken ct);
    ValueTask<int> GetSalesThisMonthCountAsync(CancellationToken ct);
    ValueTask<IReadOnlyList<ProductGetDto>> GetTopSellingProductsAsync(FilterPagination paging, CancellationToken ct);
    ValueTask<IReadOnlyList<ProductGetDto>> GetTopViewedProductsAsync(FilterPagination paging, CancellationToken ct);
    ValueTask<IReadOnlyList<SectionStat>> GetTopSectionsAsync(FilterPagination paging, CancellationToken ct);
    ValueTask<IReadOnlyList<CategoryStat>> GetTopCategoriesAsync(FilterPagination paging, CancellationToken ct);
}
