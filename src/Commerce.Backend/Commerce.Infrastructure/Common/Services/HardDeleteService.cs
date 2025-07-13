using System.Linq.Expressions;
using Commerce.Domain.Common.Entities;
using Commerce.Domain.Entities;
using Commerce.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Commerce.Infrastructure.Common.Services;

public sealed class HardDeleteBackgroundService(
    IServiceProvider serviceProvider,
    ILogger<HardDeleteBackgroundService> logger)
    : BackgroundService
{
    private static readonly TimeSpan Interval = TimeSpan.FromHours(24);
    private static readonly TimeSpan GracePeriod = TimeSpan.FromDays(7);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var cutoff = DateTime.UtcNow - GracePeriod;

            try
            {
                using var scope = serviceProvider.CreateScope();
                var sp = scope.ServiceProvider;

                await Process<Product>(sp.GetRequiredService<IProductRepository>(), cutoff, stoppingToken);
                await Process<Category>(sp.GetRequiredService<ICategoryRepository>(), cutoff, stoppingToken);
                await Process<Country>(sp.GetRequiredService<ICountryRepository>(), cutoff, stoppingToken);
                await Process<ProductManufacturer>(sp.GetRequiredService<IProductManufacturerRepository>(), cutoff, stoppingToken);
                await Process<Section>(sp.GetRequiredService<ISectionRepository>(), cutoff, stoppingToken);
                await Process<Sale>(sp.GetRequiredService<ISaleRepository>(), cutoff, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Hard-delete background sweep failed.");
            }

            await Task.Delay(Interval, stoppingToken);
        }
    }

    private static async Task Process<TEntity>(
        dynamic repo,
        DateTime cutoff,
        CancellationToken ct)
        where TEntity : IAuditableEntity
    {
        var query = (IQueryable<TEntity>)repo.Get(
            (Expression<Func<TEntity, bool>>)(e => e.IsDeleted && e.DeletedTime <= cutoff));

        var expired = await query.ToListAsync(ct);

        foreach (var entity in expired)
        {
            await repo.HardDeleteAsync(entity, cancellationToken: ct);
        }
    }
}
