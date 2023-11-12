using AutoMapper;
using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Exceptions.Admin;
using StudyThink.Domain.Exceptions.Student;
using StudyThink.Service.Common.Hasher;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.Interfaces.Admins;
using StudyThink.Service.Interfaces.Common;

namespace StudyThink.Service.Services.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public AdminService(IAdminRepository adminRepository,
        IFileService fileService,
        IMapper mapper)
    {
        this._repository = adminRepository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(AdminCreationDto model)
    {
        var exits = await _repository.GetByEmailAsync(model.Email);

        if (exits is not null)
            throw new AdminAlreadyExistsException();

        var admin = _mapper.Map<Admin>(model);

        admin.Password = Hash512.GenerateHash512(admin.Password);

        admin.CreatedAt = TimeHelper.GetDateTime();
        admin.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(admin);

        return result;
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
