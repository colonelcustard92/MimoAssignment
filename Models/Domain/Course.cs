namespace MimoAssignment.Models;

public class Course
{
    public Guid CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}