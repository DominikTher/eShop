using AutoMapper;
using eShop.Persistence.DataAccess.Models;
using ProductDto = eShop.Application.Core.Product;

namespace eShop.Persistence.Profiles;

public sealed class PeristenceProfile : Profile
{
    public PeristenceProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
