using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Models;

namespace RecipeWebsite.Controllers
{
    
    public class HomeController : Controller
    {
        private IRecipeRepository repository;
        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        //default action method
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RecipeList()
        {
            return View(repository.Recipes);            
        }

       

        [HttpGet]
        public ViewResult ViewRecipe(int recipeId)
        {
            IEnumerable<Recipe> fullList = repository.Recipes;
            Recipe recipe = fullList.FirstOrDefault(recipeTemp => recipeTemp.RecipeId == recipeId);
            
            return View(recipe);
        }
        public ViewResult ReviewRecipe(int recipeId)
        {
            IEnumerable<Recipe> fullList = RecipeRepository.getRecipes();
            Recipe recipe = fullList.FirstOrDefault(recipeTemp => recipeTemp.RecipeId == recipeId);

            return View(recipe);
        }
    }
}
