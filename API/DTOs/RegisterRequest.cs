using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public required string DisplayName { get; set; } = "iVAN IsrAEL";
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}