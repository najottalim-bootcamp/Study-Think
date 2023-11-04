using StudyThink.DataAccess.Common;

namespace StudyThink.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, IGetAll<T>
    {
        ValueTask<long> CountAsync();
        ValueTask<T> GetByIdAsync(long Id);
        ValueTask<bool> DeleteAsync(int Id);
        ValueTask<bool> UpdateAsync(T model);
        ValueTask<bool> CreateAsync(T model);

    }
}