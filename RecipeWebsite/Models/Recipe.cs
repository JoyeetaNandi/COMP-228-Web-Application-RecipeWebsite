using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        //[Range (1,1000000, ErrorMessage ="ID can't be 0")]
        [Required(ErrorMessage = "Please enter Valid Id ")]

        public int RecipeId { get; set; }
        [Required(ErrorMessage = "Please enter your name ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Recipe name ")]
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "Please enter ingredients ")]
        public string Ingredients { get; set; }
        //public string[] IngredientList => Ingredients.Split(", ");
        [Required(ErrorMessage = "Please enter recipe process ")]
        public string Process { get; set; }

        public IEnumerable<UploadImages> Images { get; set; }
    }
}
