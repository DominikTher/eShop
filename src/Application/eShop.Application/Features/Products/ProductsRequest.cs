using MediatR;

namespace eShop.Application.Features.Products;

public sealed record ProductsRequest : IRequest<IEnumerable<ProductOutput>>;