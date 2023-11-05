using Dapper;
using StudyThink.DataAccess.Interfaces.Coloborators;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;

namespace StudyThink.DataAccess.Repositories.Callaborators;

public class CallaboratorRepository : BaseRepository, ICalloboratorRepository
{
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

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM Callaborators WHERE Id={Id}";
            var result = await _connection.ExecuteAsync(query);
            return result > 0;
        }
        catch (Exception)
        {

            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<IEnumerable<Callaborator>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Callaborators order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<Callaborator>? callaborators = await _connection.ExecuteScalarAsync<IEnumerable<Callaborator>>(query, @params);

            return callaborators;
        }
        catch (Exception)
        {
            return Enumerable.Empty<Callaborator>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Callaborator> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Callaborators " +
                $"WHERE Id = {Id}";
            Callaborator callaborator = await _connection.ExecuteScalarAsync<Callaborator>(query);
            return callaborator;

        }
        catch (Exception)
        {
            return new Callaborator();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(Callaborator model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE Callaborators SET Name='{model.Name}',ImagePath='{model.ImagePath}'," +
                $"Description='{model.Description}',Email='{model.Email}',PhoneNumber='{model.PhoneNumber}'";
            var result = await _connection.ExecuteAsync(query, model);
            return result > 0;

        }
        catch (Exception)
        {

            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
