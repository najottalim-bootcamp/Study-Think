using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Service.DTOs.Teachers;

namespace StudyThink.Service.Interfaces.Teachers
{
    public interface ITeacherRepository
    {
        // Append
        ValueTask<bool> CreateAsync(TeacherCreationDto model);
        // Get
        ValueTask<Teacher> GetByIdAsync(long Id);
        ValueTask<IEnumerable<Teacher>> GetAll(PaginationParams @params);
        ValueTask<long> CountAsync();
        // Update
        ValueTask<bool> UpdateAsync(TeacherUpdateDto model);
        ValueTask<bool> UpdateImageAsync(long teacherId, IFormFile teacherImage);
        // Delete
        ValueTask<bool> DeleteAsync(long Id);
        ValueTask<bool> DeleteRange(List<long> teacherIds);
    }
}
