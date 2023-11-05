using Dapper;
using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseModulRepository : BaseRepository2, ICourseModulRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseModuls";

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

    public async ValueTask<bool> CreateAsync(CourseModul model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseModuls(Name, CourseId, CreatedAt, UpdatedAt) " +
                "VALUES (@Name, @CourseId, @CreatedAt, @UpdatedAt)";

            var patametrs = new
            {
                Name = model.Name,
                CourseId = model.CourseId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };

            var result = await _connection.ExecuteAsync(query, patametrs);

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

    public ValueTask<IEnumerable<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseModul> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseModul> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseModul>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseModul model)
    {
        throw new NotImplementedException();
    }

    ValueTask<CourseModul> IRepository<CourseModul>.GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    ValueTask<CourseModul> ICourseModulRepository.GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}
