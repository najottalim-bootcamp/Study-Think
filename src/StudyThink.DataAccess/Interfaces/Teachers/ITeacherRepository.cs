using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Teachers;

namespace StudyThink.DataAccess.Interfaces.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher>, IGetAll<Teacher>
    {
        ValueTask<Teacher> GetByPhoneNumber(string phoneNumber);
    }
}
