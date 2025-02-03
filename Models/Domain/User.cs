namespace MimoAssignment.Models;

public class User
{
    public Guid UserId { get; set; }

    public Guid CourseId { get; set; }

    public string Username { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}