using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseModulRepository : IRepository<CourseModul>
{
    ValueTask<CourseModul> GetByNameAsync(string Name);

}
