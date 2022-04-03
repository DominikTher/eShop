using AutoMapper;
using eShop.Api.Models;
using eShop.Application.Features.Products;

namespace eShop.Api.Profiles;

public sealed class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<GetProductsPaged, ProductsPagedRequest>();
    }
}
