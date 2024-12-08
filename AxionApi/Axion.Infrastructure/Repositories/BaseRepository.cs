using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Axion.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly IConfiguration _config;

    protected BaseRepository(IConfiguration config)
    {
        _config = config;
    }

    protected SqlConnection CreateConnection()
    {
        return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    }
}
