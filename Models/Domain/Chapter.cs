using MimoAssignment.Models.Domain;

namespace MimoAssignment.Models;

public class Chapter
{
    public Guid ChapterId { get; set; }

    public string Description { get; set; } = null!;

    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}