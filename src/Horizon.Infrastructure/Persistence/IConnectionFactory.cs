using Microsoft.Data.SqlClient;

namespace Horizon.Infrastructure.Persistence;

public interface IConnectionFactory
{
    SqlConnection Create();
}
