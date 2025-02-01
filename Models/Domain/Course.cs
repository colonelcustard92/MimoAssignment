namespace MimoAssignment.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}