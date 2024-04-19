using System.ComponentModel.DataAnnotations;

namespace shop.models
{
    public class UserLoginRequestDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }
}
