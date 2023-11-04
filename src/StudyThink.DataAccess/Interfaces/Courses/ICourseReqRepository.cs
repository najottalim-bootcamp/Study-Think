using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseReqRepository : IRepository<CourseRequirments>
{
    ValueTask<CourseRequirments> GetByNameAsync(string name);
}
