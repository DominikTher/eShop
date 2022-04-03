using eShop.Application.Core;

namespace eShop.Application.Contracts.Persistence.Products.Queries;

public interface IGetPagedProductsQueryHandler
{
    Task<IEnumerable<Product>> Execute(GetPagedProductsQuery getPagedProductsQuer, CancellationToken cancellationToken);
}
