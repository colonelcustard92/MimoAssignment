using Microsoft.AspNetCore.Mvc;
using MimoAssignment.Models.ViewModels;
using MimoAssignment.Services;

namespace MimoAssignment.Controllers;

[Route("/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    private readonly LessonsService _lessonsService;

    public LessonsController(LessonsService lessonsService)
    {
        _lessonsService = lessonsService;
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompletedLessonViewModel model)
    {
        var updateResponse = await _lessonsService.UpdateCompletedLessonAsync(model);
        return Ok(updateResponse);
    }
}