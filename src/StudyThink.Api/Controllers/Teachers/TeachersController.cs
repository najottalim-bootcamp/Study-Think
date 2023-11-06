using Microsoft.AspNetCore.Mvc;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Service.Interfaces.Teachers;

namespace StudyThink.Api.Controllers.Teachers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetById(long id)
    {
        Teacher teacher = await _teacherService.GetByIdAsync(id);

        return Ok(teacher);
    }
}
