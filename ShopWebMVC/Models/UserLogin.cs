
using System.ComponentModel.DataAnnotations;

namespace ShopWebMVC.Models
{
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Email cannot be left blank")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password cannot be left blank")]
        public string Password { get; set; } = null!;
    }
}
