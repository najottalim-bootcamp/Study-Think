using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.Interfaces.Corses;
using StudyThink.Service.Interfaces.Courses;
using System.Security.Cryptography.X509Certificates;

namespace StudyThink.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository courseRepository;
    private readonly IMapper _mapper;
    public CourseService(ICourseService courseService, IMapper mapper)
    {
        this.courseRepository = courseRepository;
        this._mapper = mapper;
    }
    public async ValueTask<long>  CountAsync()=> await courseRepository.CountAsync();



    public async ValueTask<bool> CreateAsync(CourseCreationDto model)
    {

        Course course = _mapper.Map<Course>(model);

        var result = await courseRepository.CreateAsync(course);

        return result;

    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> courseIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Course> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CourseUpdateDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourse)
    {
        throw new NotImplementedException();
    }
}
