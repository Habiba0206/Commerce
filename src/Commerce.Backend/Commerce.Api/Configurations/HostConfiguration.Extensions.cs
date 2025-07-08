using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Commerce.Domain.Common.Serializers;
using Commerce.Infrastructure.Common.Serializers;
using Commerce.Infrastructure.Common.EventBus.Brokers;
using Commerce.Infrastructure.Common.Caching;
using Commerce.Infrastructure.Common.EventBus.Extensions;
using Commerce.Application.Common.Settings;
using Commerce.Persistence.Caching.Brokers;
using Commerce.Application.Common.EventBus.Brokers;
using Commerce.Domain.Constants;
using Commerce.Persistence.DataContexts;
using Commerce.Persistence.Repositories.Interfaces;
using Commerce.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using MediatR;
using Commerce.Application.Common.Services;
using Commerce.Infrastructure.Common.Services;
using Commerce.Api.Configurations;
using Commerce.Application.Categories.Services;
using Commerce.Application.Countries.Services;
using Commerce.Application.Products.Services;
using Commerce.Application.Manufacturers.Services;
using Commerce.Application.Sales.Services;
using Commerce.Application.Sections.Services;
using Commerce.Infrastructure.Sections.Services;
using Commerce.Infrastructure.Sales.Services;
using Commerce.Infrastructure.Manufacturers.Services;
using Commerce.Infrastructure.Products.Services;
using Commerce.Infrastructure.Countries.Services;
using Commerce.Infrastructure.Categories.Services;
using Commerce.Api.Behaviours;
using Commerce.Api.Middlewares;

namespace Commerce.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddSerializers(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IJsonSerializationSettingsProvider, JsonSerializationSettingsProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        // register configurations 
        builder.Services.Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));

        // register fluent validation
        builder.Services.AddValidatorsFromAssemblies(Assemblies).AddFluentValidationAutoValidation();

        return builder;
    }

    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        builder.Services.AddLazyCache();

        builder.Services.AddSingleton<ICacheBroker, LazyMemoryCacheBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddEventBus(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddMassTransit(configuration =>
            {
                var serviceProvider = configuration.BuildServiceProvider();
                var jsonSerializerSettingsProvider = serviceProvider.GetRequiredService<IJsonSerializationSettingsProvider>();

                configuration.RegisterAllConsumers(Assemblies);
                configuration.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);

                    cfg.UseNewtonsoftJsonSerializer();
                    cfg.UseNewtonsoftJsonDeserializer();

                    cfg.ConfigureNewtonsoftJsonSerializer(settings => jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                    cfg.ConfigureNewtonsoftJsonDeserializer(settings => jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                });
            });

        builder.Services.AddSingleton<IEventBusBroker, MassTransitEventBusBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var dbConnectionString =
            builder.Configuration.GetConnectionString(DataAccessConstants.DbConnectionString) ??
            Environment.GetEnvironmentVariable(DataAccessConstants.DbConnectionString);

        var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();

        logger?.LogInformation("Environment: {Environment}", builder.Environment.EnvironmentName);
        logger?.LogInformation("Connection String Present: {HasConnection}", !string.IsNullOrEmpty(dbConnectionString));
        logger?.LogDebug("Connection String: {ConnectionString}", dbConnectionString);

        builder.Services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(dbConnectionString); });

        return builder;
    }

    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        //registering repositories
        builder
            .Services
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductManufacturerRepository, ProductManufacturerRepository>()
            .AddScoped<ISaleRepository, SaleRepository>()
            .AddScoped<ISectionRepository, SectionRepository>();

        //registering services
        builder
            .Services
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<ICountryService, CountryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IProductManufacturerService, ProductManufacturerService>()
            .AddScoped<ISaleService, SaleService>()
            .AddScoped<ISectionService, SectionService>()
            .AddScoped<IFileUploadService, FileUploadService>();

        return builder;
    }

    private static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddMediatR(conf => { conf.RegisterServicesFromAssemblies(Assemblies.ToArray()); });

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            }
        );

        return builder;
    }

    //private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    //{
    //    var serviceScope = app.Services.CreateScope();
    //    await serviceScope.ServiceProvider.InitializeSeedAsync();

    //    return app;
    //}

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Commerce Api",
                Version = "v1"
            });
        });

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>
            (options => { options.SuppressModelStateInvalidFilter = true; });

        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static async ValueTask<WebApplication> MigratedataBaseSchemasAsync(this WebApplication app)
    {
        var serviceScopeFactory = app.Services.GetRequiredKeyedService<IServiceScopeFactory>(null);

        await serviceScopeFactory.MigrateAsync<AppDbContext>();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseStaticFiles();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseIdentityInfrustructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}