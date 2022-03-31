using AutoMapper;
using eShop.Application.Core;
using eShop.Application.Features.Products;

namespace eShop.Application.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Product, ProductOutput>();
    }
}
