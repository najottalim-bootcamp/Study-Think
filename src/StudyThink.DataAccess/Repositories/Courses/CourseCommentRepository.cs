using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseCommentRepository : BaseRepository, ICourseCommentRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseComments";

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

    public async ValueTask<bool> CreateAsync(CourseComment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseComments(Comment, StudentId, CourseId, AdminId, CreatedAt, UpdatedAt) " +
                "VALUES (@Comment, @StudentId, @CourseId, @AdminId, @CreatedAt, @UpdatedAt)";

            var parametrs = new
            {
                Comment = model.Comment,
                StudentId = model.StudentId,
                CourseId = model.CourseId,
                AdminId = model.AdminId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };

            var result = await _connection.ExecuteAsync(query, parametrs);

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
            string query = $"DELETE FROM CourseComments WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseComments order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<CourseComment>? courseComments = await _connection.ExecuteScalarAsync<IEnumerable<CourseComment>>(query, @params);

            return courseComments;
        }
        catch (Exception)
        {
            return Enumerable.Empty<CourseComment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<CourseComment> GetByComment(string comment)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<CourseComment> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM CourseComments " +
                $"WHERE Id = {Id}";
            CourseComment courseComment = await _connection.ExecuteScalarAsync<CourseComment>(query);
            return courseComment;

        }
        catch (Exception)
        {
            return new CourseComment();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseComment>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(CourseComment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update Courses SET Comment='{model.Comment}', StudentId={model.StudentId}, CourseId='{model.CourseId}',CreatedAt={model.CreatedAt},UpdatedAt={model.UpdatedAt}, AdminId={model.AdminId}";
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
