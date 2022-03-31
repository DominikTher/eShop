using eShop.Application.Core;

namespace eShop.Application.Contracts.Persistence.Products.Commands;

public interface IUpdateProductDescriptionCommandHandler
{
    Task<Product?> Execute(UpdateProductDescriptionCommand updateProductDescriptionCommand, CancellationToken cancellationToken);
}
