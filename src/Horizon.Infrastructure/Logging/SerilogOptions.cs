namespace Horizon.Infrastructure.Logging;

public sealed class SerilogOptions
{
    public string Level { get; set; } = string.Empty;
    public ConsoleOptions Console { get; set; } = new();
}

public sealed class ConsoleOptions
{
    public bool Enabled { get; set; }
    public string Template { get; set; } = string.Empty;
}
