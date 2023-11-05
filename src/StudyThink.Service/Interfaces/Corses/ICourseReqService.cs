using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;
using StudyThink.Service.DTOs.Courses.CourseRequirment;

namespace StudyThink.Service.Interfaces.Corses;

public interface ICourseReqService
{
    ValueTask<bool> CreateAsync(CourseReqCretionDto model);
    ValueTask<bool> UpdateAsync(CourseReqUpdateDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseRequirment> GetById(long id);
    ValueTask<IEnumerable<CourseRequirment>> GetAll(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> DeleteRange(List<long> CourseReqIds);
    ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourseReq);


}
