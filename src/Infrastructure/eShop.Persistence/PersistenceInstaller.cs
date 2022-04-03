using eShop.Application.Contracts.Persistence.Products.Commands;
using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Application.Contracts.Persistence.Queries;
using eShop.Application.Core;
using eShop.Persistence.DataAccess;
using eShop.Persistence.Products.Commands;
using eShop.Persistence.Products.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Persistence;

public static class PersistenceInstaller
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, PersistenceConfiguration persistenceConfiguration)
    {
        serviceCollection.AddAutoMapper(typeof(PersistenceInstaller));
        serviceCollection.AddDbContextFactory<EShopDbContext>(options =>
        {
            options.UseSqlServer(persistenceConfiguration.ConnectionString);
            options.EnableSensitiveDataLogging(persistenceConfiguration.EnableSensitiveDataLogging);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        serviceCollection.AddScoped<IGetAllProductsQueryHandler, GetAllProductsQueryHandler>();
        serviceCollection.AddScoped<IGetProductByIdQueryHandler, GetProductByIdQueryHandler>();
        serviceCollection.AddScoped<IUpdateProductDescriptionCommandHandler, UpdateProductDescriptionCommandHandler>();
        serviceCollection.AddScoped<IGetPagedProductsQueryHandler, GetPagedProductsQueryHandler>();
        serviceCollection.AddScoped<IGetProductsCountQueryHandler, GetProductsCountQueryHandler>();

        return serviceCollection;
    }
}
