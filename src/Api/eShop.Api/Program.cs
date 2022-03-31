using eShop.Api;
using eShop.Application;
using eShop.Application.Core;
using eShop.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
builder
    .Services
    .AddApi()
    .AddApplication()
    .AddPersistence(new PersistenceConfiguration
    {
        ConnectionString = builder.Configuration.GetConnectionString("eShopDbContext"),
        EnableSensitiveDataLogging = builder.Configuration.GetValue<bool>("EnableSensitiveDataLogging")
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SupportNonNullableReferenceTypes());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
