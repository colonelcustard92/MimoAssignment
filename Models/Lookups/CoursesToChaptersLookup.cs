namespace MimoAssignment.Models;

public partial class CoursesToChaptersLookup
{
    public Guid CourseId { get; set; }

    public Guid ChapterId { get; set; }

    public int Order { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}