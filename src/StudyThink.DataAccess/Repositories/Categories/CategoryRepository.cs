using Dapper;
using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;

namespace StudyThink.DataAccess.Repositories.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Categories";

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

    public async ValueTask<bool> CreateAsync(Category model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Categories(Name, Description) " +
                "VALUES (@Name, @Description)";

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

    public ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Category> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Category>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Category model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
