namespace eShop.Application.Contracts.Persistence.Products.Queries;

public sealed record GetPagedProductsQuery
{
    public int Page { get; init; }
    public int Size { get; init; }
}
