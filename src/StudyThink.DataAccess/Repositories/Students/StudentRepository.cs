using Dapper;
using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Enums;

namespace StudyThink.DataAccess.Repositories.Students;

public class StudentRepository : BaseRepository, IStudentRepository
{
    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Students";

            long result = await _connection.ExecuteScalarAsync<long>(query);
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

    public async ValueTask<bool> CreateAsync(Student model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO Students(FirstName, LasntName, DateOfBith, UserName, Password, Email, PhoneNumber, Gender, CreatedAt, UpdatedAt, DeletedAt, ImagePath) " +
                "VALUES (@FirstName, @LasntName, @DateOfBith, @UserName, @Password, @Email, @PhoneNumber, @Gender, @CreatedAt, @UpdatedAt, @DeletedAt, @ImagePath)";

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
            string query = $"DELETE FROM Students WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<Student>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Students order by Id desc " +
               $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            IEnumerable<Student>? students = await _connection.ExecuteScalarAsync<IEnumerable<Student>>(query, @params);

            return students;
        }
        catch (Exception)
        {
            return Enumerable.Empty<Student>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<Student> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Student>> GetByGenderAsync(Gender gender)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Student> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Students " +
                $"WHERE Id = {Id}";
            Student students = await _connection.ExecuteScalarAsync<Student>(query);
            return students;

        }
        catch (Exception)
        {
            return new Student();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<IEnumerable<Student>> GetByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Student> GetByUserNameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Student>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(Student model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update Students SET FirstName='{model.FirstName}',LastName='{model.LastName}',DateOfBirth={model.DateOfBirth},UserName='{model.Username}'," +
                $"Password='{model.Password}',Email='{model.Email}',PhoneNumber='{model.PhoneNumber}',Gender='{model.Gender}'," +
                $"CreatedAt={model.CreatedAt},UpdatedAt={model.UpdatedAt},DeltedAt={model.DeletedAt},ImagePath='{model.ImagePath}'";
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

    public Task<bool> UpdateImageAsync(long studentId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
