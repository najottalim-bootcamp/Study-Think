using Microsoft.AspNetCore.Mvc;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Controllers.Courses;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;

    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpGet]
    public async ValueTask<long> CountAsync()
    {
        var result = await courseService.CountAsync();
        return result;
    }

    [HttpPost]
    public async ValueTask<bool> CreateAsync([FromForm] CourseCreationDto courseCreationDto)
    {
        var result = await courseService.CreateAsync(courseCreationDto);
        return result;
    }
}
