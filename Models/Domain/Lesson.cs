namespace MimoAssignment.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public string LessonDescription { get; set; } = null!;

    public int Order { get; set; }

    public int ChapterId { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;
}