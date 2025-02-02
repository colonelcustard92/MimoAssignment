using Microsoft.EntityFrameworkCore;
using MimoAssignment.Models;
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
            if (String.IsNullOrWhiteSpace(userName)) return new List<AchievementViewModel>();

            return await _context.UserToAchievementLookups
                .Where(x => x.User.Username == userName)
                .Select(x => new AchievementViewModel
                {
                    AchievementId = x.AchievementId,
                    IsCompleted = x.IsCompleted,
                    AchievementProgress = x.Achievement.AchievementProgress
                })
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            //Log to App Insights
        }
      


    }
}