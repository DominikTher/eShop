using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Application;

public static class ApplicationInstaller
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(ApplicationInstaller));
        serviceCollection.AddMediatR(typeof(ApplicationInstaller));

        return serviceCollection;
    }
}
