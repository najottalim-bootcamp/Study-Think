using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseModulRepository : IRepository<CourseRequirments>,
    IGetAll<CourseRequirments>, ISearchable<CourseRequirments>
{
    ValueTask<CourseRequirments> GetByNameAsync(string name);
}
