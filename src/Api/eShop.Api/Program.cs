using eShop.Api;
using eShop.Application;
using eShop.Application.Core;
using eShop.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddApi()
    .AddApplication()
    .AddPersistence(new PersistenceConfiguration
    {
        ConnectionString = builder.Configuration.GetConnectionString("eShopDbContext"),
        EnableSensitiveDataLogging = builder.Configuration.GetValue<bool>("EnableSensitiveDataLogging")
    });

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "eShop v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "eShop v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
