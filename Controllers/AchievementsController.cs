using Microsoft.AspNetCore.Mvc;
using MimoAssignment.Services;

namespace MimoAssignment.Controllers;

[Route("/[controller]")]
[ApiController]
public class AchievementsController : ControllerBase
{
    private readonly AchievementsService _achievementsService;

    public AchievementsController(AchievementsService achievementsService)
    {
        _achievementsService = achievementsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string userName)
    {
        var result = await _achievementsService.ReturnAllAchievementsForGivenUser(userName);
        if (!result.Any()) return NotFound("No Achievements Found for this User");
        return Ok(result);
    }
}