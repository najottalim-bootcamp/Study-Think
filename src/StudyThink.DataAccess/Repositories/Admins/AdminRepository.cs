using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;

namespace StudyThink.DataAccess.Repositories.Admins;

public class AdminRepository : BaseRepository, IAdminRepository
{
    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(Admin model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Admin>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Admin> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Admin> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Admin>> GetByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Admin>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(Admin model)
    {
        throw new NotImplementedException();
    }
}
