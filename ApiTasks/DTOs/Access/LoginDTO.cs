﻿using System.ComponentModel.DataAnnotations;

namespace ApiTasks.DTOs.Access
{
    public class LoginDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
