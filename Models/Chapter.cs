using System;
using System.Collections.Generic;

namespace MimoAssignment.Models;

public partial class Chapter
{
    public int ChapterId { get; set; }

    public string Description { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
