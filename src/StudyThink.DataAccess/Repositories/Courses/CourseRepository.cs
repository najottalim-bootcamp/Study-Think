using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;
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
            string query = $"INSERT INTO Courses(Name,Description,CategoryId,Price,ImagePath,TotalPrice,Lessons,Duration,Language,DiscountPrice,CourseReqId) " +
                $"VALUES ('{model.Name}', '{model.Description}', '{model.CategoryId}', '{model.Price}', '{model.ImagePath}', '{model.TotalPrice}', '{model.Lessons}', '{model.Duration}', '{model.Language}','{model.DiscountPrice}', '{model.CourseReqId}')";

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
            string query = $"DELETE FROM Courses WHERE Id={Id}";
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

   public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
{
    try
    {
        await _connection.OpenAsync();
        string query = $"SELECT * FROM Courses ORDER BY Id DESC " +
            $"OFFSET {@params.GetSkipCount()} ROWS FETCH NEXT {@params.PageSize} ROWS ONLY";

        var result = await _connection.QueryAsync<Course>(query);
        return result;
    }
    catch (Exception)
    {
        return Enumerable.Empty<Course>();
    }
    finally
    {
        _connection.Close();
    }
}

    public async ValueTask<Course> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Courses " +
                $"WHERE Id = {Id}";
            Course course = await _connection.QueryFirstOrDefaultAsync<Course>(query);
            return course;

        }
        catch (Exception)
        {
            return new Course();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<IEnumerable<Course>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Course>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(Course model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE Courses SET " +
                "Name = @Name, " +
                "Description = @Description, " +
                "CategoryId = @CategoryId, " +
                "Price = @Price, " +
                "ImagePath = @ImagePath, " +
                "TotalPrice = @TotalPrice, " +
                "Lessons = @Lessons, " +
                "Duration = @Duration, " +
                "Language = @Language, " +
                "DiscountPrice = @DiscountPrice, " +
                "CreatedAt = @CreatedAt, " +
                "UpdatedAt = @UpdatedAt " +
                "WHERE Id = @Id";

            var result = await _connection.ExecuteAsync(query, new
            {
                model.Name,
                model.Description,
                model.CategoryId,
                model.Price,
                model.ImagePath,
                model.TotalPrice,
                model.Lessons,
                model.Duration,
                model.Language,
                model.DiscountPrice,
                model.CreatedAt,
                model.UpdatedAt,
                model.Id
            });

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

    public ValueTask<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
