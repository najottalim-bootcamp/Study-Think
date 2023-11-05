using Microsoft.AspNetCore.Mvc;
using StudyThink.Service.DTOs.Category;
using StudyThink.Service.Interfaces.Categories;

namespace StudyThink.Api.Controllers.Categories;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CategoryCreationDto dto)
        => Ok(await _service.CreateAsync(dto));
}
