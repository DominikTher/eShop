using eShop.Application.Core;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed record ProductRequest : IRequest<Product>
{
    public int ProductId { get; init; }
}
