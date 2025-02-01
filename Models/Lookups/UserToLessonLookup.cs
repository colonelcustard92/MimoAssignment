namespace MimoAssignment.Models;

public partial class UserToLessonLookup
{
    public string UserId { get; set; } = null!;

    public int LessonId { get; set; }

    public DateTime TimeStarted { get; set; }

    public DateTime TimeCompleted { get; set; }

    public int TimesSolved { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}