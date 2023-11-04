﻿using StudyThink.DataAccess.Common;

namespace StudyThink.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, IGetAll<T>
    {
        ValueTask<long> CountAsync();
        ValueTask<T> GetByIdAsync(long Id);
        ValueTask<bool> Delete(int Id);
        ValueTask<bool> Update(T model);
        ValueTask<bool> Create(T model);
    }
}