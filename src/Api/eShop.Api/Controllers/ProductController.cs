using AutoMapper;
using eShop.Api.Models;
using eShop.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/products")]
[ApiController]
public sealed class ProductController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public ProductController(
        IMediator mediator,
        IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductOutput>>> GetProducts(CancellationToken cancellationToken)
    {
        var products = await mediator.Send(new ProductsRequest(), cancellationToken);

        return Ok(products);
    }

    [MapToApiVersion("2.0")]
    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<PagedProductOutput>>> GetProductsPaged([FromQuery] GetProductsPaged getProductsPaged, CancellationToken cancellationToken)
    {
        var productsPagedRequest = mapper.Map<ProductsPagedRequest>(getProductsPaged);
        var products = await mediator.Send(productsPagedRequest, cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOutput>> GetProduct(int id, CancellationToken cancellationToken)
    {
        var product = await mediator.Send(new ProductRequest { ProductId = id }, cancellationToken);

        return Ok(product);
    }

    [HttpPatch]
    public async Task<ActionResult<ProductOutput>> UpdateProductDescription(ProductDescriptionUpdateRequest productDescriptionUpdateRequest, CancellationToken cancellationToken)
    {
        var product = await mediator.Send(productDescriptionUpdateRequest, cancellationToken);

        return Ok(product);
    }
}