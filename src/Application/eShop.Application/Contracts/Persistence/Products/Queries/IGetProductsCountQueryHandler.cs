namespace eShop.Application.Contracts.Persistence.Products.Queries;

public interface IGetProductsCountQueryHandler
{
    Task<int> Execute(CancellationToken cancellationToken);
}
