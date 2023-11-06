﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Service.DTOs.Teachers;
using StudyThink.Service.Interfaces.Teachers;

namespace StudyThink.Api.Controllers.Teachers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    private readonly int _maxPageSize = 30;

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

    [HttpPost]
    public async ValueTask<IActionResult> PostTeacher([FromForm]TeacherCreationDto teacher)
    {
        bool result = await _teacherService.CreateAsync(teacher);

        return Ok(result);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromForm] int page)
    {
        IEnumerable<Teacher> teachers = await _teacherService.GetAllAsync(new PaginationParams(page, _maxPageSize));

        return Ok(teachers);
    }
}
