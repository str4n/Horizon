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
            var section = configuration.GetSection(SectionName);

            var options = new DatabaseOptions();

            section.Bind(options);

            return new ConnectionFactory(options.ConnectionString);
        });

        return services;
    }
}
