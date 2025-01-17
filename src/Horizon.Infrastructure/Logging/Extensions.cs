using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Horizon.Infrastructure.Logging;

internal static class Extensions
{
    private const string SectionName = "logger";

    public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration) 
        => services.Configure<SerilogOptions>(configuration.GetSection(SectionName));

    public static IHostBuilder UseLogging(this IHostBuilder host, IConfiguration configuration)
    {
        var serilogOptions = configuration.BindOptions<SerilogOptions>(SectionName);

        host.UseSerilog((ctx, cfg) =>
        {
            var level = GetLogEventLevel(serilogOptions.Level);

            cfg.Enrich.FromLogContext()
                .MinimumLevel.Is(level)
                .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName);

            if (serilogOptions.Console.Enabled)
            {
                cfg.WriteTo.Console(outputTemplate: serilogOptions.Console.Template);
            }
        });

        return host;
    }
    
    private static LogEventLevel GetLogEventLevel(string level)
        => Enum.TryParse<LogEventLevel>(level, true, out var logLevel)
            ? logLevel
            : LogEventLevel.Information;
}
