using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Service.DTOs.Courses.CourseComment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseCommnetService : ICourseCommentService
{
    private readonly ICourseCommentRepository _repository;
    private readonly IFileService _fileService;

    public CourseCommnetService(ICourseCommentRepository repository,
        IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(CourseCommentCreationDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> CourseCommentIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseComment> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseCommentUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
