namespace MimoAssignment.Models;

public class UserToAchievementLookup
{
    public Guid UserId { get; set; }

    public Guid AchievementId { get; set; }

    public int IsCompleted { get; set; }

    public int AchievementProgress { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}