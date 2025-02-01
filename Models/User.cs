using System;
using System.Collections.Generic;

namespace MimoAssignment.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
