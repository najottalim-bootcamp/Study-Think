using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    public CourseService(ICourseRepository repo, IMapper mapper)
    {
        this._courseRepository = repo;
        this._mapper = mapper;
    }
    public async ValueTask<long> CountAsync() => await _courseRepository.CountAsync();



    public async ValueTask<bool> CreateAsync(CourseCreationDto model)
    {

        Course course = _mapper.Map<Course>(model);

        var result = await _courseRepository.CreateAsync(course);

        return result;

    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        var result =await _courseRepository.DeleteAsync(Id);
        return result;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> courseIds)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
    {
        var result = await _courseRepository.GetAllAsync(@params);
        return result;
    }

    public async ValueTask<Course> GetByIdAsync(long Id)
    {
        var result =await _courseRepository.GetByIdAsync(Id);
        return result;
    }

    public ValueTask<bool> UpdateAsync(CourseUpdateDto model)
    {
        Course course= _mapper.Map<Course>(model);
        course.UpdatedAt = DateTime.UtcNow;
        var result = _courseRepository.UpdateAsync(course);

        return result;
    }

    public ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourse)
    {
        throw new NotImplementedException();
    }
}
