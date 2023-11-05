using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseReqRepository : BaseRepository, ICourseReqRepository
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

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM CourseRequirments WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseRequirments" +
                $" order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<CourseRequirment>? courseRequirments = await _connection.ExecuteScalarAsync<IEnumerable<CourseRequirment>>(query, @params);

            return courseRequirments;
        }
        catch (Exception)
        {
            return Enumerable.Empty<CourseRequirment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseRequirment> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseRequirments " +
                $"WHERE Id = {Id}";
            CourseRequirment courseRequirment = await _connection.ExecuteScalarAsync<CourseRequirment>(query);
            return courseRequirment;

        }
        catch (Exception)
        {
            return new CourseRequirment();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<CourseRequirment> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseRequirment>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(CourseRequirment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update CourseRequirments SET Requirments='{model.Requirments}', CourseId='{model.CourseId}',CreatedAt={model.CreatedAt},UpdatedAt={model.UpdatedAt}";
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
