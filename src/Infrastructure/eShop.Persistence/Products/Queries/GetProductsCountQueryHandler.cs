using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Products.Queries;

public sealed class GetProductsCountQueryHandler : IGetProductsCountQueryHandler
{
    private readonly IDbContextFactory<EShopDbContext> dbContextFactory;

    public GetProductsCountQueryHandler(IDbContextFactory<EShopDbContext> dbContextFactory)
        => this.dbContextFactory = dbContextFactory;

    public async Task<int> Execute(CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();

        return await dbContext.Products.CountAsync(cancellationToken);
    }
}
