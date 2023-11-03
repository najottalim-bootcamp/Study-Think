namespace StudyThink.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ValueTask<long> CountAsync();
        ValueTask<T> GetByIdAsync(long Id);
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask<bool> Delete(int Id);
        ValueTask<bool> Update(T model);
        ValueTask<bool> Create(T model);
    }
}