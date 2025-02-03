namespace MimoAssignment.Models.ViewModels
{ 
    public class CompletedLessonViewModel
    { 
        public Guid LessonId { get; set; }
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public string LessonDescription { get; set; } = string.Empty;
        public DateTime TimeStarted { get; set; }
        public DateTime TimeCompleted { get; set; }
        public bool IsCompleted { get; set; }
    }
}
