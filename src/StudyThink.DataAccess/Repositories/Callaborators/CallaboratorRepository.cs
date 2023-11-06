using Dapper;
using StudyThink.DataAccess.Interfaces.Coloborators;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;

namespace StudyThink.DataAccess.Repositories.Callaborators;

public class CallaboratorRepository : BaseRepository2, ICalloboratorRepository
{
    public CallaboratorRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Callaborators";

            long result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> CreateAsync(Callaborator model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Callaborators(Name, ImagePath, Description, Email, PhoneNumber) " +
                "VALUES (@Name, @ImagePath, @Description, @Email, @PhoneNumber)";

            var result = await _connection.ExecuteAsync(query, model);

            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Callaborator>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Callaborator> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Callaborator model)
    {
        throw new NotImplementedException();
    }
}
