using AutoMapper;
using eShop.Application.Contracts.Persistence.Queries;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed class ProductsRequestHandler : IRequestHandler<ProductsRequest, IEnumerable<ProductOutput>>
{
    private readonly IGetAllProductsQueryHandler getAllProductsQueryHandler;
    private readonly IMapper mapper;

    public ProductsRequestHandler(
        IGetAllProductsQueryHandler getAllProductsQueryHandler,
        IMapper mapper)
    {
        this.getAllProductsQueryHandler = getAllProductsQueryHandler;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ProductOutput>> Handle(ProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await getAllProductsQueryHandler.Execute(cancellationToken);
        
        return mapper.Map<IEnumerable<ProductOutput>>(products);
    }
}
