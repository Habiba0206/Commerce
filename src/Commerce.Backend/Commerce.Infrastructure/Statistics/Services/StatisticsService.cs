using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Commerce.Application.Products.Models;
using Commerce.Application.Products.Services;
using Commerce.Application.Sales.Services;
using Commerce.Application.Statistics.Models;
using Commerce.Application.Statistics.Services;
using Commerce.Domain.Common.Queries;
using Commerce.Domain.Entities;
using Commerce.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Statistics.Services;

public class StatisticsService(
        IProductService productService,
        ISaleService saleService,
        IMapper mapper) : IStatisticsService
{
    private IQueryable<Product> Products() => productService.Get();
    private IQueryable<Sale> Sales() => saleService.Get();

    public async ValueTask<ProductGetDto?> GetBestSellingProductAsync(CancellationToken cancellationToken)
    {
        var topId = await Sales()
            .GroupBy(s => s.ProductId)
            .OrderByDescending(g => g.Sum(s => s.QuantitySold))
            .Select(g => g.Key)
            .FirstOrDefaultAsync(cancellationToken);

        if (topId == Guid.Empty) return null;

        var product = await productService.GetByIdAsync(topId, cancellationToken: cancellationToken);
        return product is null ? null : mapper.Map<ProductGetDto>(product);
    }

    public async ValueTask<ProductGetDto?> GetMostViewedProductAsync(CancellationToken cancellationToken)
    {
        var product = await Products()
                   .OrderByDescending(p => p.Views)
                   .FirstOrDefaultAsync(cancellationToken);

        return mapper.Map<ProductGetDto>(product);
    }
    public async ValueTask<int> GetItemsOnSaleCountAsync(CancellationToken cancellationToken)
        => await Products().CountAsync(p => p.Availability, cancellationToken);

    public async ValueTask<int> GetSalesThisMonthCountAsync(CancellationToken cancellationToken)
    {
        var monthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        return await Sales().CountAsync(s => s.SaleDate >= monthStart, cancellationToken);
    }

    public async ValueTask<IReadOnlyList<ProductGetDto>> GetTopSellingProductsAsync(
        FilterPagination paging,
        CancellationToken ct)
    {
        var topIds = await Sales()
            .GroupBy(s => s.ProductId)
            .OrderByDescending(g => g.Sum(s => s.QuantitySold))
            .Select(g => g.Key)
            .ApplyPagination(paging)
            .ToListAsync(ct);

        return await Products()
            .Where(p => topIds.Contains(p.Id))
            .ProjectTo<ProductGetDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }

    public async ValueTask<IReadOnlyList<ProductGetDto>> GetTopViewedProductsAsync(
            FilterPagination paging,
            CancellationToken ct)
        => await Products()
               .OrderByDescending(p => p.Views)
               .ApplyPagination(paging)
               .ProjectTo<ProductGetDto>(mapper.ConfigurationProvider)
               .ToListAsync(ct);

    public async ValueTask<IReadOnlyList<SectionStat>> GetTopSectionsAsync(
         FilterPagination paging, CancellationToken ct)
    {
        var grouped = await Products()
            .Include(p => p.Section)                        // make sure Section loaded
            .GroupBy(p => new { p.SectionId, p.Section.Name })
            .Select(g => new
            {
                g.Key.SectionId,
                g.Key.Name,
                Total = g.Sum(p => p.Profit * p.Amount)     // still float here
            })
            .OrderByDescending(x => x.Total)
            .ApplyPagination(paging)
            .ToListAsync(ct);                               // SQL stops here ✔

        return grouped
            .Select(x => new SectionStat(x.SectionId, x.Name, x.Total))
            .ToList();
    }

    public async ValueTask<IReadOnlyList<CategoryStat>> GetTopCategoriesAsync(
            FilterPagination paging, CancellationToken ct)
    {
        var grouped = await Products()
            .Include(p => p.Category)
            .GroupBy(p => new { p.CategoryId, p.Category.Name })
            .Select(g => new
            {
                g.Key.CategoryId,
                g.Key.Name,
                Total = g.Sum(p => p.Profit * p.Amount)
            })
            .OrderByDescending(x => x.Total)
            .ApplyPagination(paging)
            .ToListAsync(ct);

        return grouped
            .Select(x => new CategoryStat(x.CategoryId, x.Name, x.Total))
            .ToList();
    }
}