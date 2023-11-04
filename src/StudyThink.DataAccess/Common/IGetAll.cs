using StudyThink.DataAccess.Utils;

namespace StudyThink.DataAccess.Common;

public interface IGetAll<T>
{
    public Task<IList<T>> GetALlAsync(PaginationParams @params);
}
