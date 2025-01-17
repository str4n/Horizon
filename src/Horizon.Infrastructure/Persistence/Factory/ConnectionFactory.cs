using Microsoft.Data.SqlClient;

namespace Horizon.Infrastructure.Persistence.Factory;

internal sealed class ConnectionFactory(string connectionString) : IConnectionFactory
{
    public SqlConnection Create() => new(connectionString);
}
