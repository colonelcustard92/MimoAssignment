using Microsoft.AspNetCore.Mvc;
using MimoAssignment.Models.ViewModels;
using MimoAssignment.Contexts;
using MimoAssignment.Services;

namespace MimoAssignment.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    { 
      
        [HttpPost]
        public async Task<IActionResult> PostCompletedLesson([FromBody] CompletedLessonViewModel completedLesson)
        {
            LessonsService LS = new LessonsService();
            var completedLessons = await LS.GetCompletedLessonAsync(completedLesson);
            return Ok(completedLessons);
        }
    }
}

