using eShop.Api.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace eShop.Api;

public static class ApiInstaller
{
    public static IServiceCollection AddApi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(ApiInstaller));
        serviceCollection
            .AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
        serviceCollection
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "eShop v1", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "eShop v2", Version = "v2" });
                options.SupportNonNullableReferenceTypes();
            });
        serviceCollection.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        serviceCollection.AddVersionedApiExplorer(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.GroupNameFormat = "'v'VVV";
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        serviceCollection.AddValidatorsFromAssembly(typeof(ApiInstaller).Assembly);

        return serviceCollection;
    }
}