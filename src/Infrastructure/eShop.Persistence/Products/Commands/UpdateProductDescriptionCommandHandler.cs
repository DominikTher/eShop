using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Commands;
using eShop.Application.Core;
using eShop.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Products.Commands;

public sealed class UpdateProductDescriptionCommandHandler : IUpdateProductDescriptionCommandHandler
{
    private readonly IDbContextFactory<EShopDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public UpdateProductDescriptionCommandHandler(
        IDbContextFactory<EShopDbContext> dbContextFactory,
        IMapper mapper)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<Product?> Execute(UpdateProductDescriptionCommand updateProductDescriptionCommand, CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();
        var product = await dbContext.Products.FindAsync(new object[] { updateProductDescriptionCommand.ProductId }, cancellationToken);

        if (product is null) return null;

        var updatedProduct = product with { Description = updateProductDescriptionCommand.ProductDescription };
        dbContext.Products.Attach(updatedProduct);
        dbContext.Entry(updatedProduct).Property(x => x.Description).IsModified = true;
        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<Product>(updatedProduct);
    }
}
