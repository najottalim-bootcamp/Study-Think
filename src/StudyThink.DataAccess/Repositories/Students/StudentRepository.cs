using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Enums;

namespace StudyThink.DataAccess.Repositories.Students;

public class StudentRepository : BaseRepository, IStudentRepository
{
    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(Student model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
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
