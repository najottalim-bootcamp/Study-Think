using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Courses;
using System.ComponentModel;

namespace StudyThink.Service.Interfaces.Courses;

public  interface ICourseRepository:IRepository<Course>
{

    ValueTask<IEnumerable<Course>> GetByNameAsync (string name);

}
