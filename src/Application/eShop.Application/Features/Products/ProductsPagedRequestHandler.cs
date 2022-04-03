using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Queries;
using eShop.Application.Core;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed class ProductsPagedRequestHandler : IRequestHandler<ProductsPagedRequest, PagedProductOutput>
{
    private readonly IGetPagedProductsQueryHandler getPagedProductsQueryHandler;
    private readonly IGetProductsCountQueryHandler getProductsCountQueryHandler;
    private readonly IMapper mapper;

    public ProductsPagedRequestHandler(
        IGetPagedProductsQueryHandler getPagedProductsQueryHandler,
        IGetProductsCountQueryHandler getProductsCountQueryHandler,
        IMapper mapper)
    {
        this.getPagedProductsQueryHandler = getPagedProductsQueryHandler;
        this.getProductsCountQueryHandler = getProductsCountQueryHandler;
        this.mapper = mapper;
    }

    public async Task<PagedProductOutput> Handle(ProductsPagedRequest request, CancellationToken cancellationToken)
    {
        var pageCount = getProductsCountQueryHandler.Execute(cancellationToken);
        var products = getPagedProductsQueryHandler.Execute(mapper.Map<GetPagedProductsQuery>(request), cancellationToken);

        await Task.WhenAll(pageCount, products);

        return new PagedProductOutput
        {
            Pages = int.Parse(Math.Ceiling(((decimal) await pageCount) / request.Size).ToString()),
            Products = mapper.Map<IEnumerable<ProductOutput>>(await products)
        };
    }
}