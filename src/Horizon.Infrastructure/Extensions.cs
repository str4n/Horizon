using Horizon.Infrastructure.Logging;
using Horizon.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Horizon.Infrastructure;

public static class Extensions
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;

        builder.Services.AddLogging();
        builder.Host.UseLogging(configuration);
        builder.Services.AddPersistence(configuration);

        return builder;
    }
    
    public static TOptions BindOptions<TOptions>(this IConfiguration configuration, string sectionName) where TOptions : class, new()
        => BindOptions<TOptions>(configuration.GetSection(sectionName));
    
    private static TOptions BindOptions<TOptions>(this IConfiguration section) where TOptions : class, new()
    {
        var options = new TOptions();
        section.Bind(options);

        return options;
    }
}
