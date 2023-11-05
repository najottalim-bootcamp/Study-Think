using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Service.DTOs.Courses.CourseComment;

namespace StudyThink.Service.Interfaces.Corses;

public interface ICourseCommentService
{
    ValueTask<bool> CreateAsync(CourseCommentCreationDto model);
    ValueTask<bool> UpdateAsync(CourseCommentUpdateDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<bool> DeleteRangeAsync(List<long> CourseCommentIds);
    ValueTask<CourseComment> GetById(long id);
    ValueTask<long> CountAsync();
    ValueTask<IEnumerable<CourseComment>> GetAll(PaginationParams @params);
    ValueTask<bool> UpdateImage(long CourseCommentId,IFormFile imageCourseComment);

}
