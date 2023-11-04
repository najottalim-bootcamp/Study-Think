using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Course;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseCommentRepository : IRepository<CourseComment>
{
    ValueTask<CourseComment> GetByComment(string comment);
}