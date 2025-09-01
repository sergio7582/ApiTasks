using System.ComponentModel.DataAnnotations;

namespace ApiTasks.DTOs.Access
{
    public class UsuarioDTO
    {
        [MinLength(5), MaxLength(20)]
        public required string Username { get; set; }
        [MinLength(5), MaxLength(100)]
        public required string Name { get; set; }
        [MinLength(5), MaxLength(100)]
        public required string Lastname { get; set; }
        [MinLength(5), MaxLength(50)]
        public required string Email { get; set; }
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
