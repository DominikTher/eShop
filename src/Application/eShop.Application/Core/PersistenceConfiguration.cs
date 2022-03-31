namespace eShop.Application.Core;

public sealed record PersistenceConfiguration
{
    public string ConnectionString { get; init; } = string.Empty;
    public bool EnableSensitiveDataLogging { get; init; }
}
