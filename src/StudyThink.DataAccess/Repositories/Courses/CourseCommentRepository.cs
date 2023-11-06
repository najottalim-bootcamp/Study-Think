﻿using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseCommentRepository : BaseRepository2, ICourseCommentRepository
{
    public CourseCommentRepository(string connectionString) : base(connectionString)
    {
    }

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

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseComment> GetByComment(string comment)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseComment> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<CourseComment>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseComment model)
    {
        throw new NotImplementedException();
    }
}
