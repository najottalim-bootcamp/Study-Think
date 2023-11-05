using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseRepository : BaseRepository, ICourseRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Courses";

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

    public async ValueTask<bool> CreateAsync(Course model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Courses(Name, Description, CategoryId, Price, ImagePath, TotalPrice, Lessons, Duration, Language, DiscountPrice, CourseReqId, CreatedAt, UpdatedAt) " +
                "VALUES (@Name, @Description, @CategoryId, @Price, @ImagePath, @TotalPrice, @Lessons, @Duration, @Language, @DiscountPrice, @CourseReqId, @CreatedAt, UpdatedAt)";

            var patametrs = new
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                ImagePath = model.ImagePath,
                TotalPrice = model.TotalPrice,
                Lessons = model.Lessons,
                Duration = model.Duration,
                Language = model.Language,
                DiscountPrice = model.DiscountPrice,
                CourseReqId = model.CourseReqId,
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

    public ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Course> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Course>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Course>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Course model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
