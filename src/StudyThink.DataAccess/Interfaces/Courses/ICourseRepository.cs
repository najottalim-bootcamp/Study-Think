using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course>,
    IGetAll<Course>, ISearchable<Course>
{

    ValueTask<IEnumerable<Course>> GetByNameAsync(string name);

    ValueTask<bool> UpdateImageAsync(long categoryId, string imagePath);

}
