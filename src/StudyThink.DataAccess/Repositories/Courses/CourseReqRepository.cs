using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseReqRepository : BaseRepository2, ICourseReqRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseRequirments";

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

    public async ValueTask<bool> CreateAsync(CourseRequirment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseRequirments(Requirments, CourseId, CreatedAt, UpdatedAt) " +
                "VALUES (@Requirments, @CourseId, @CreatedAt, @UpdatedAt)";

            var patametrs = new
            {
                Requirments = model.Requirments,
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

    public ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseRequirment> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseRequirment> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseRequirment>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseRequirment model)
    {
        throw new NotImplementedException();
    }
}
