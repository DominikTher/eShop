namespace eShop.Application.Contracts.Persistence.Products.Commands;

public sealed record UpdateProductDescriptionCommand
{
    public int ProductId { get; init; }
    public string? ProductDescription { get; init; }
}
