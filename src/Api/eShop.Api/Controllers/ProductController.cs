using eShop.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eShop.Api.Controllers;

[Route("api/products")]
[ApiController]
public sealed class ProductController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductOutput>>> GetProducts(CancellationToken cancellationToken)
    {
        var products = await mediator.Send(new ProductsRequest(), cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOutput>> GetProduct(int id, CancellationToken cancellationToken)
    {
        var product = await mediator.Send(new ProductRequest { ProductId = id }, cancellationToken);

        return Ok(product);
    }

    [HttpPatch]
    public ActionResult<ProductOutput> UpdateProductDescription(CancellationToken cancellationToken)
    {
        return Ok();
    }
}