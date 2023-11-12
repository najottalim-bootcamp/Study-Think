using AutoMapper;
using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Domain.Exceptions.Admin;
using StudyThink.Domain.Exceptions.AdminExseptions;
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

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        var existAdmin = await _repository.GetByIdAsync(Id);

        if (existAdmin is null)
            throw new AdminNotFound();

        var result = await _repository.DeleteAsync(Id);
        return result;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> adminIds)
    {
        foreach (var i in adminIds)
        {
            Admin student = await _repository.GetByIdAsync(i);

            if (student != null)
            {
                await _repository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Admin>> GetAll(PaginationParams @params)
    {
        IEnumerable<Admin> admins = await _repository.GetAllAsync(@params);

        if (admins is null)
            throw new AdminNotFound();

        return admins;
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
