using System.ComponentModel.DataAnnotations;

namespace ApiTasks.DTOs.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }
        [MinLength(1), MaxLength(100)]
        public required string Title { get; set; }

        [MinLength(5),MaxLength(200)]
        public required string Description { get; set; }

        public required int IdCategory { get; set; }

        public required DateTime DateLimit { get; set; }

    }
}
