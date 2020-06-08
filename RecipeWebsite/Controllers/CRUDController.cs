using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private IRecipeRepository repository;
        public CRUDController(IRecipeRepository repo)
        {
            repository = repo;
        }
        [HttpGet]

        public ViewResult AddRecipe()
        {
            return View(new Recipe());
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                return RedirectToAction("RecipeList", "Home");
            }
            return View(recipe);

        }
        [HttpGet]
        public ViewResult Update(int recipeId) =>
            View(repository.Recipes
                .FirstOrDefault(p => p.RecipeId == recipeId));

        [HttpPost]
        public IActionResult Update(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult Create() => View("Update", new Recipe());

        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.RecipeName} was deleted!";
            }

            return RedirectToAction("RecipeList", "Home");
        }

    }
}
