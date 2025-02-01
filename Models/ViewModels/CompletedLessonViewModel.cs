namespace MimoAssignment.Models.ViewModels
{
    public class CompletedLessonViewModel
    {
        public int LessonId { get; set; }
        public string LessonDescription { get; set; } = string.Empty;
        public DateTime TimeStarted { get; set; }
        public DateTime TimeCompleted { get; set; }
        public bool IsCompleted => TimeCompleted > TimeStarted;

        // Optional: Helper to format lesson duration for display
        public string LessonDuration =>
            IsCompleted ? (TimeCompleted - TimeStarted).ToString(@"hh\:mm\:ss") : "In Progress";
    }
}
