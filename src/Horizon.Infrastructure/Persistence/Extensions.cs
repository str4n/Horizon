using Horizon.Infrastructure.Persistence.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Horizon.Infrastructure.Persistence;

internal static class Extensions
{
    private const string SectionName = "Database";
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionFactory>(_ =>
        {
            var options = configuration.BindOptions<DatabaseOptions>(SectionName);

            return new ConnectionFactory(options.ConnectionString);
        });

        return services;
    }
}
