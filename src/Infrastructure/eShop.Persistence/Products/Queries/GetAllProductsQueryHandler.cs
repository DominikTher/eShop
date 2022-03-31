using AutoMapper;
using eShop.Application.Contracts.Persistence.Queries;
using eShop.Application.Core;
using eShop.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Products.Queries;

public sealed class GetAllProductsQueryHandler : IGetAllProductsQueryHandler
{
    private readonly IDbContextFactory<EShopDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public GetAllProductsQueryHandler(
        IDbContextFactory<EShopDbContext> dbContextFactory,
        IMapper mapper)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Product>> Execute(CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        var products = await dbContext.Products.ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<Product>>(products);
    }
}
