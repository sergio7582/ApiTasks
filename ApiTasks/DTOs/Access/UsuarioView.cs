using System.ComponentModel.DataAnnotations;

namespace ApiTasks.DTOs.Access
{
    public class UsuarioView
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime LastLogin { get; set; }
    }
}
