namespace eShop.Application.Features.Products;

public sealed record PagedProductOutput
{
    public int Pages { get; init; }
    public IEnumerable<ProductOutput> Products { get; init; } = Enumerable.Empty<ProductOutput>();
}