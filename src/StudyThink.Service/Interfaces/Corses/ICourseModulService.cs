using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.CourseModel;

namespace StudyThink.Service.Interfaces.Corses;

public interface ICourseModulService
{
    ValueTask<bool> CreateAsync(CourseModulCreationDto model);
    ValueTask<bool> UpdateAsync(CourseModulUpdateDto model);
    ValueTask<IEnumerable<CourseModul>> GetAll(PaginationParams @params);
    ValueTask<CourseModul> GetById(long id);
    ValueTask<long> CountAsync();
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<bool> DeleteRange(List<long> CourseModulIds);
    ValueTask<bool> UpdateImageAsync(long CourseModulId, IFormFile imageCourseModul);
}
