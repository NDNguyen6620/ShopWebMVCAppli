

using System.ComponentModel.DataAnnotations;

namespace ShopWebMVC.Models
{
    public class Category : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? TotalPro {  get; set; }
    }
}
