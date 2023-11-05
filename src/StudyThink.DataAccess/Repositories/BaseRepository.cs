using Dapper;
using System.Data.SqlClient;

namespace StudyThink.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly SqlConnection _connection;

    public BaseRepository()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new SqlConnection("Server=;Database=StudyThink;Trusted_Connection=True;TrustServerCertificate=true;");
    }
}
