using Dapper;
using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Enums;

namespace StudyThink.DataAccess.Repositories.Students;

public class StudentRepository : BaseRepository2, IStudentRepository
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
            string query = "INSERT INTO Students(FirstName, LastName,DateOfBirth,UserName,Password, Email,PhoneNumber, Gender, CreatedAt, UpdatedAt, DeletedAt) " +
                "VALUES (@FirstName, @LastName,@DateOfBirth,@UserName,@Password,@ Email,@PhoneNumber,@ Gender, @CreatedAt,@ UpdatedAt,@ DeletedAt)";

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
            string query = $"DELETE FROM StudentRepository WHERE Id={Id}";
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

    public ValueTask<IEnumerable<Student>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Student> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Student>> GetByGenderAsync(Gender gender)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Student> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
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

    public ValueTask<bool> UpdateAsync(Student model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long studentId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
