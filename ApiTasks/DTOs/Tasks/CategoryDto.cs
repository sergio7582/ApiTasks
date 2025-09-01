using System.ComponentModel.DataAnnotations;

namespace ApiTasks.DTOs.Tasks
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(100)]
        public required string Title { get; set; }
        public string? Icon { get; set; }

    }
}
