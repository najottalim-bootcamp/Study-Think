using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.CourseRequirment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseReqService : ICourseReqService
{
    private readonly ICourseReqRepository _repository;
    private readonly IFileService _fileService;

    public CourseReqService(ICourseReqRepository reqRepository,
        IFileService fileService)
    {
        this._repository = reqRepository;
        this._fileService = fileService;
    }

    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(CourseReqCretionDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> CourseReqIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseRequirment> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseReqUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
