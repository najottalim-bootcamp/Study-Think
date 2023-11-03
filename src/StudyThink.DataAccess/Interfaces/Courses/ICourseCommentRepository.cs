using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Course;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseCommentRepository: IRepository<CourseComment>, IGetAll<CourseComment>
{
    ValueTask<CourseComment> GetByComment(string comment);
}