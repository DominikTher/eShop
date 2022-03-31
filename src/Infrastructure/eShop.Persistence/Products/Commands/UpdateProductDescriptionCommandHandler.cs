using eShop.Application.Contracts.Persistence.Products.Commands;
using eShop.Application.Core;

namespace eShop.Persistence.Products.Commands;

public sealed class UpdateProductDescriptionCommandHandler : IUpdateProductDescriptionCommandHandler
{
    public UpdateProductDescriptionCommandHandler()
    {

    }

    public Task<Product> Execute(UpdateProductDescriptionCommand updateProductDescriptionCommand)
    {
        throw new NotImplementedException();
    }
}
