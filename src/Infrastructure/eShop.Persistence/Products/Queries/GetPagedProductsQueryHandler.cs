using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Application.Core;
using eShop.Persistence.DataAccess;
using eShop.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Products.Queries;

public sealed class GetPagedProductsQueryHandler : IGetPagedProductsQueryHandler
{
    private readonly IDbContextFactory<EShopDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public GetPagedProductsQueryHandler(
        IDbContextFactory<EShopDbContext> dbContextFactory,
        IMapper mapper)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Product>> Execute(GetPagedProductsQuery getPagedProductsQuery, CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        var products = await dbContext
            .Products
            .ApplyPagination(getPagedProductsQuery.Page, getPagedProductsQuery.Size)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<Product>>(products);
    }
}
