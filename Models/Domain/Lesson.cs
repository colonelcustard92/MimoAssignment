namespace MimoAssignment.Models.Domain;

public class Lesson
{
    public Guid LessonId { get; set; }

    public string LessonDescription { get; set; } = null!;

    public int Order { get; set; }

    public Guid ChapterId { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;
}