using ShopWebMVC.Common;
using System.ComponentModel.DataAnnotations;

namespace ShopWebMVC.Models
{
    public class Admin : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be left blank")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Email cannot be left blank")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password cannot be left blank")]
        public string Password { get; set; } = null!;
        public TypeAdmin typeAdmin { get; set; }
    }
}
