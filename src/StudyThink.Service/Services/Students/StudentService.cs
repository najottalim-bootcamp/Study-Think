using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.Interfaces.Studentsk;

namespace StudyThink.Service.Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentService _studentService;
    private readonly IMapper mapper;
    public async ValueTask<long> CountAsync()
    {
        return await _studentService.CountAsync();
    }

    public async ValueTask<bool> CreateAsync(StudentCreationDto model)
    {
        Student student=mapper.Map<Student>(model);
        
        return result;
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> studentIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Student>> GetAll(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Student> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(StudentUpdateDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateImageAsync(long studentId, IFormFile imageStudent)
    {
        throw new NotImplementedException();
    }
}
