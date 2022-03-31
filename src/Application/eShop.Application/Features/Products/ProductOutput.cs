﻿namespace eShop.Application.Features.Products;

public sealed record ProductOutput
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string ImgUri { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string? Description { get; init; }
}