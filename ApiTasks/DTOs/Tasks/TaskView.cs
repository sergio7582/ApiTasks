namespace ApiTasks.DTOs.Tasks
{
    public class TaskView
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? DateLimit { get; set; }
        public DateTime? CreateAt { get; set; }
        
    }
}
