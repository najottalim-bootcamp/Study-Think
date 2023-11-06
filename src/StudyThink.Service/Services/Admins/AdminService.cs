using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.Interfaces.Admins;
using StudyThink.Service.Interfaces.Common;

namespace StudyThink.Service.Services.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IFileService _fileService;

    public AdminService(IAdminRepository adminRepository,
        IFileService fileService)
    {
        this._repository = adminRepository;
        this._fileService = fileService;
    }

    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(AdminCreationDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> adminIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Admin>> GetAll(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Admin> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(AdminUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
