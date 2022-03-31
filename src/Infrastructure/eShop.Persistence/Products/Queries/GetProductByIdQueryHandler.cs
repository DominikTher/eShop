using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Application.Core;
using eShop.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Products.Queries;

public sealed class GetProductByIdQueryHandler : IGetProductByIdQueryHandler
{
    private readonly IDbContextFactory<EShopDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public GetProductByIdQueryHandler(
        IDbContextFactory<EShopDbContext> dbContextFactory,
        IMapper mapper)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<Product> Execute(int id, CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        var product = await dbContext.Products.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

        return mapper.Map<Product>(product);
    }
}
