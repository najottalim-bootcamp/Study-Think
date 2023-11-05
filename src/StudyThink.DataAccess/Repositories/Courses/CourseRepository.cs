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
            string query = $"SELECT * FROM Courses order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<Course>? categories = await _connection.ExecuteScalarAsync<IEnumerable<Course>>(query, @params);

            return categories;
        }
        catch (Exception)
        {
            return Enumerable.Empty<Course>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Course> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Courses " +
                $"WHERE Id = {Id}";
            Course course = await _connection.ExecuteScalarAsync<Course>(query);
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
            string query = $"Update Courses SET Name='{model.Name}',Description='{model.Description}',CategoryId={model.CategoryId},Price={model.Price},ImagePath='{model.ImagePath}'," +
                $"TotalPrice={model.TotalPrice},Lessons={model.Lessons},Duration={model.Duration},Language='{model.Language}',DiscountPrice={model.DiscountPrice}," +
                $"CreatedAt={model.CreatedAt},UpdatedAt={model.UpdatedAt}";
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

    public ValueTask<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
