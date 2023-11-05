using Dapper;
using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseModulRepository : BaseRepository, ICourseModulRepository
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

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM CourseModuls WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseModuls order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<CourseModul>? courseModuls = await _connection.ExecuteScalarAsync<IEnumerable<CourseModul>>(query, @params);

            return courseModuls;
        }
        catch (Exception)
        {
            return Enumerable.Empty<CourseModul>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseModul> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseModuls " +
                $"WHERE Id = {Id}";
            CourseModul courseModul = await _connection.ExecuteScalarAsync<CourseModul>(query);
            return courseModul;

        }
        catch (Exception)
        {
            return new CourseModul();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<CourseModul> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseModul>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(CourseModul model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update CourseModuls SET Name='{model.Name}', CourseId='{model.CourseId}',CreatedAt={model.CreatedAt},UpdatedAt={model.UpdatedAt}";
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
