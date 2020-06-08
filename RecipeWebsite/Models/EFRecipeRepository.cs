using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeWebsite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;
        
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes.Include(rec => rec.Images);

        //public void SaveRecipe(Recipe recipe)
        //{
        //    context.Recipes.Add(recipe);
        //    context.SaveChanges();
        //}


        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);

                if (recipeEntry != null)
                {
                    recipeEntry.RecipeId = recipe.RecipeId;
                    recipeEntry.RecipeName = recipe.RecipeName;
                    recipeEntry.UserName = recipe.UserName;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Process = recipe.Process;
                    recipeEntry.Images = recipe.Images;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeId == recipeId);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }

        public void AddUploadedImage(UploadImages uploadImages)
        {
            context.UploadImages.Add(uploadImages);
            context.SaveChanges();
        }
    }
}
