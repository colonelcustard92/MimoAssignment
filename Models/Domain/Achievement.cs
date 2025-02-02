namespace MimoAssignment.Models;

public class Achievement
{
    public string AchievementId { get; set; } = null!;

    public string AchievementDescription { get; set; } = null!;
    
    public int AchievementProgress { get; set; }
}