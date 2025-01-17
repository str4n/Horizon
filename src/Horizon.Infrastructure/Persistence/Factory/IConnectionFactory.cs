using Microsoft.Data.SqlClient;

namespace Horizon.Infrastructure.Persistence.Factory;

public interface IConnectionFactory
{
    SqlConnection Create();
}
