using eShop.Application.Core;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed record ProductDescriptionUpdateRequest : IRequest<Product>
{
    public int ProductId { get; init; }
    public string? ProductDescription { get; init; }
}
