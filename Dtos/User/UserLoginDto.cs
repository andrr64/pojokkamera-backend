using System.ComponentModel.DataAnnotations;

namespace pojokkamera_backend.Dtos.User
{
    public class UserLoginDto
    {
        /// <summary>
        /// Bisa username atau email untuk login.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password asli (akan dicek hash-nya).
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
