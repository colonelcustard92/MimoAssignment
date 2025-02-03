using Microsoft.EntityFrameworkCore;
using MimoAssignment.Contexts;
using MimoAssignment.Models.ViewModels;

namespace MimoAssignment.Services;

public class AchievementsService
{
    private readonly MimoTestContext _context;

    public AchievementsService(MimoTestContext context)
    {
        _context = context;
    }

    public async Task<List<AchievementViewModel>> ReturnAllAchievementsForGivenUser(string userName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(userName)) return new List<AchievementViewModel>();

            var result = await _context.UserToAchievementLookups
                .Where(x => x.User.Username == userName)
                .Select(x => new AchievementViewModel
                {
                    AchievementId = x.AchievementId.ToString(),
                    IsCompleted = x.IsCompleted,
                    AchievementProgress = x.AchievementProgress
                    
                }).ToListAsync();

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            //Log to App Insights
        }
    }
}