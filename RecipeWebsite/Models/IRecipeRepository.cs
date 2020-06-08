using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }

        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeId);

        void AddUploadedImage(UploadImages uploadImages);

    }
}
