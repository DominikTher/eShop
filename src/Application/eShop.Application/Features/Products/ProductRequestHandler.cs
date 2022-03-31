using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Application.Core;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed class ProductRequestHandler : IRequestHandler<ProductRequest, Product>
{
    private readonly IGetProductByIdQueryHandler getProductByIdQueryHandler;
    private readonly IMapper mapper;

    public ProductRequestHandler(
        IGetProductByIdQueryHandler getProductByIdQueryHandler,
        IMapper mapper)
    {
        this.getProductByIdQueryHandler = getProductByIdQueryHandler;
        this.mapper = mapper;
    }

    public async Task<Product> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var product = await getProductByIdQueryHandler.Execute(request.ProductId, cancellationToken);

        return mapper.Map<Product>(product);
    }
}
