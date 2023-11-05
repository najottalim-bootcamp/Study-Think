using Dapper;
using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;

namespace StudyThink.DataAccess.Repositories.Admins;

public class AdminRepository : BaseRepository, IAdminRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Admins";

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

    public async ValueTask<bool> CreateAsync(Admin model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Admins(FirstName, LastName, PhoneNumber, Email, Password, Role, CreatedAt, UpdatedAt, DeletedAt) " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Password, @Role, @CreatedAt, @UpdatedAt, @DeletedAt)";

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

            string query = $"DELETE FROM Admins WHERE Id = {Id}";

            var result = await _connection.ExecuteAsync(query);

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

    public ValueTask<IEnumerable<Admin>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Admin> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Admin> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Admin>> GetByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Admin>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Admin model)
    {
        throw new NotImplementedException();
    }
}
