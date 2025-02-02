using System;
using System.Collections.Generic;

namespace MimoAssignment.Models;

public partial class Achievement
{
    public Guid AchievementId { get; set; }

    public string AchievementDescription { get; set; } = null!;
}
