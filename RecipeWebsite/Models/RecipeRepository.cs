using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class RecipeRepository
    {
        private static List<Recipe> recipes = new List<Recipe>();
        //get recipes
        public static IEnumerable<Recipe> getRecipes()
        {
            return recipes;
        }
        public static void SaveRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

    }
}
