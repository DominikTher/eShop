using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Models;

public sealed record GetProductsPaged
{
    [FromQuery(Name = "page")]
    public int Page { get; init; } = 1;

    [FromQuery(Name = "size")]
    public int Size { get; init; } = 5;
}