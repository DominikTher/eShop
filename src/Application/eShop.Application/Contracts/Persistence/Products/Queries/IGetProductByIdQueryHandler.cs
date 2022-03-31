using eShop.Application.Core;

namespace eShop.Application.Contracts.Persistence.Products.Queries;

public interface IGetProductByIdQueryHandler
{
    Task<Product> Execute(int id, CancellationToken cancellationToken);
}
