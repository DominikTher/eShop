using MediatR;

namespace eShop.Application.Features.Products;

public sealed record ProductsPagedRequest : IRequest<PagedProductOutput>
{
    public int Page { get; init; } = 1;
    public int Size { get; init; } = 5;
}
