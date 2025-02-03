using Microsoft.EntityFrameworkCore;
using MimoAssignment.Contexts;
using MimoAssignment.Models.ViewModels;

namespace MimoAssignment.Services;

public class LessonsService
{
    private readonly MimoTestContext _context;

    public LessonsService(MimoTestContext context)
    {
        _context = context;
    }

    public async Task<string> UpdateCompletedLessonAsync(CompletedLessonViewModel model)
    {
        //Get all Lessons for the given UserId
        var lesson = await _context.UserToLessonLookups.FirstOrDefaultAsync(x =>
            x.LessonId == model.LessonId && x.UserId == model.UserId);
        if(lesson is null) return "Lesson not found or no access!";
        
        //Otherwise, update the lesson
        lesson.TimeStarted = model.TimeStarted;
        lesson.TimeCompleted = model.TimeCompleted;
        if (model.IsCompleted) lesson.TimesSolved++;
        try
        {
            await _context.SaveChangesAsync();
            return "Lesson Updated! :)";
        }
        catch (Exception ex)
        {
          
            _context.ChangeTracker.Clear();
            
            // Log the exception (To App Insights, theoretically!)
            Console.WriteLine($"Error updating lesson: {ex.Message}");
            return "Oops, something went wrong!";
        }
    }
}