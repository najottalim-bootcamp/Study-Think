using Microsoft.AspNetCore.Mvc;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Service.Interfaces.Teachers;

namespace StudyThink.Api.Controllers.Teachers
{
    [ApiController]
    [Route("api/[countroller]/[api]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async ValueTask<IActionResult> GetById(long id)
        {
            Teacher teacher = await _teacherService.GetByIdAsync(id);

            return Ok(teacher);
        }
    }
}
