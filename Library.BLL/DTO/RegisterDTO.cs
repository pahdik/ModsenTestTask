using System.ComponentModel.DataAnnotations;

namespace Library.BLL.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Username not specified")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "The string length must be between 3 and 20 characters")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="No password specified")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$",
            ErrorMessage = "Password must contain one uppercase, letter one lowercase letter, one number")]
        public string Password { get; set; }
    }
}
