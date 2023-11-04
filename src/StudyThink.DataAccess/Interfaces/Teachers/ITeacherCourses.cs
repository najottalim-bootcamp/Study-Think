using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Entities.Teachers;

namespace StudyThink.DataAccess.Interfaces.Teachers
{
    internal interface ITeacherCourses
    {
        ValueTask<long> CountTeacherCourses(long teacherId);
        ValueTask<IEnumerable<Course>> GetTeacherCourses(long teacherId);
        ValueTask<Teacher> GetCourseTeacher(long courseId);
        ValueTask<bool> DeleteTeacherFromCourse(long teacherId, long courseId);
        ValueTask<bool> ChangeTeacherCourse(long teacherId, long oldCourse, long newCourseId);
        ValueTask<bool> AddTeacherToCourse(long teacherId, long courseId);
    }
}