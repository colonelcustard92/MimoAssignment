using System.ComponentModel.DataAnnotations;

namespace MimoAssignment.Models.ViewModels;

public class CompletedLessonViewModel
{
    public Guid LessonId { get; set; }
    public Guid UserId { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss", ApplyFormatInEditMode = true)]
    public DateTime TimeStarted { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss", ApplyFormatInEditMode = true)]
    public DateTime TimeCompleted { get; set; }
    public bool IsCompleted { get; set; }
}