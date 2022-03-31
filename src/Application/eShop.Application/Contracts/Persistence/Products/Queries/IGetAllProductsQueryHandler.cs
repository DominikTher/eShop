using eShop.Application.Core;

namespace eShop.Application.Contracts.Persistence.Queries;

public interface IGetAllProductsQueryHandler
{
    Task<IEnumerable<Product>> Execute(CancellationToken cancellationToken);
}
