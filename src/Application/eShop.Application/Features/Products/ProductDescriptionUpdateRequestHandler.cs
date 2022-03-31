using AutoMapper;
using eShop.Application.Contracts.Persistence.Products.Commands;
using eShop.Application.Core;
using MediatR;

namespace eShop.Application.Features.Products;

public sealed class ProductDescriptionUpdateRequestHandler : IRequestHandler<ProductDescriptionUpdateRequest, Product>
{
    private readonly IUpdateProductDescriptionCommandHandler updateProductDescriptionCommandHandler;
    private readonly IMapper mapper;

    public ProductDescriptionUpdateRequestHandler(
        IUpdateProductDescriptionCommandHandler updateProductDescriptionCommandHandler,
        IMapper mapper)
    {
        this.updateProductDescriptionCommandHandler = updateProductDescriptionCommandHandler;
        this.mapper = mapper;
    }

    public async Task<Product> Handle(ProductDescriptionUpdateRequest request, CancellationToken cancellationToken)
    {
        var product = await updateProductDescriptionCommandHandler.Execute(mapper.Map<UpdateProductDescriptionCommand>(request), cancellationToken);

        return mapper.Map<Product>(product);
    }
}
