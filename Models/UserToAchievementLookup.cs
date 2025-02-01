namespace MimoAssignment.Models;

public partial class UserToAchievementLookup
{
    public string UserId { get; set; } = null!;

    public string AchievementId { get; set; } = null!;

    public int IsCompleted { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
