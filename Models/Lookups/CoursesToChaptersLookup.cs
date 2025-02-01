namespace MimoAssignment.Models;

public partial class CoursesToChaptersLookup
{
    public string CourseId { get; set; } = null!;

    public int ChapterId { get; set; }

    public int Order { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}