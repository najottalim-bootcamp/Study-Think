using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.Course;

namespace StudyThink.Service.Interfaces.Corses;

public interface ICourseService
{
    ValueTask<bool> CreateAsync(CourseCreationDto model);
    ValueTask<Course> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Course>> GetAll(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(CourseUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourse); 
    ValueTask<bool> DeleteRange(List<long>  courseIds);

}
