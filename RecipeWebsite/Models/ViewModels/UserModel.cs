using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models.ViewModels
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
