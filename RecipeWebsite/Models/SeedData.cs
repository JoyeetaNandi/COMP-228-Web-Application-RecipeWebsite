using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipeWebsite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(

                    new Recipe
                    {
                        UserName = "Nisha",
                        RecipeName = "CHILI BEAN-AND-BULGUR CAKES",
                        Ingredients = "½ cup whole-kernel bulgur wheat, 2 Tbsp vegetable oil, 1 Tbsp tomato paste, " +
                                     "1 tsp chili powder, ½ tsp ground cumin, Large pinch cayenne pepper, ¼ cup reduced - fat sour cream, " +
                                     "Zest and juice of 1 lime, Kosher salt, 1 15 - oz can kidney beans, drained and rinsed",
                        Process = "1. Combine the bulgur with 1 1/2 cups of water in a small saucepan. Bring to a boil, " +
                                     "reduce heat to medium low, cover and simmer until tender, 10 to 12 minutes." +
                                     " Drain off the excess water and cool the bulgur completely. " +
                                     "2.Heat the oil in a small skillet over medium - high heat.Add the tomato paste, chili powder," +
                                     "cumin and cayenne and whisk until the oil is yellow and the spices are fragrant," +
                                     "about 45 seconds.Remove from the heat and let the chili oil cool to room temperature. " +
                                     "3.Whisk together the sour cream, lime zest and juice, a pinch of salt and 1 tablespoon water in a small bowl." +
                                     "Refrigerate until ready to serve. " +
                                     "4.Position an oven rack at the top of the oven and preheat the broiler.Line a baking sheet with foil." +
                                     "Combine the beans, cooked bulgur, cheese"

                    },
                    new Recipe
                    {
                        UserName = "Neoti",
                        RecipeName = "CHILI BEAN-AND-BULGUR CAKES",
                        Ingredients = "½ cup whole-kernel bulgur wheat, 2 Tbsp vegetable oil, 1 Tbsp tomato paste, " +
                                     "1 tsp chili powder, ½ tsp ground cumin, Large pinch cayenne pepper, ¼ cup reduced - fat sour cream, " +
                                     "Zest and juice of 1 lime, Kosher salt, 1 15 - oz can kidney beans, drained and rinsed",
                        Process = "1. Combine the bulgur with 1 1/2 cups of water in a small saucepan. Bring to a boil, " +
                                     "reduce heat to medium low, cover and simmer until tender, 10 to 12 minutes." +
                                     " Drain off the excess water and cool the bulgur completely. " +
                                     "2.Heat the oil in a small skillet over medium - high heat.Add the tomato paste, chili powder," +
                                     "cumin and cayenne and whisk until the oil is yellow and the spices are fragrant," +
                                     "about 45 seconds.Remove from the heat and let the chili oil cool to room temperature. " +
                                     "3.Whisk together the sour cream, lime zest and juice, a pinch of salt and 1 tablespoon water in a small bowl." +
                                     "Refrigerate until ready to serve. " +
                                     "4.Position an oven rack at the top of the oven and preheat the broiler.Line a baking sheet with foil." +
                                     "Combine the beans, cooked bulgur, cheese"


                        //Price = 48.95m
                    },
                new Recipe
                {
                    UserName = "Shipra",
                    RecipeName = "CHILI BEAN-AND-BULGUR CAKES",
                    Ingredients = "½ cup whole-kernel bulgur wheat, 2 Tbsp vegetable oil, 1 Tbsp tomato paste, " +
                                 "1 tsp chili powder, ½ tsp ground cumin, Large pinch cayenne pepper, ¼ cup reduced - fat sour cream, " +
                                 "Zest and juice of 1 lime, Kosher salt, 1 15 - oz can kidney beans, drained and rinsed",
                    Process = "1. Combine the bulgur with 1 1/2 cups of water in a small saucepan. Bring to a boil, " +
                                 "reduce heat to medium low, cover and simmer until tender, 10 to 12 minutes." +
                                 " Drain off the excess water and cool the bulgur completely. " +
                                 "2.Heat the oil in a small skillet over medium - high heat.Add the tomato paste, chili powder," +
                                 "cumin and cayenne and whisk until the oil is yellow and the spices are fragrant," +
                                 "about 45 seconds.Remove from the heat and let the chili oil cool to room temperature. " +
                                 "3.Whisk together the sour cream, lime zest and juice, a pinch of salt and 1 tablespoon water in a small bowl." +
                                 "Refrigerate until ready to serve. " +
                                 "4.Position an oven rack at the top of the oven and preheat the broiler.Line a baking sheet with foil." +
                                 "Combine the beans, cooked bulgur, cheese"

                    //Price = 19.50m
                },
                new Recipe
                {
                    UserName = "Beauty",
                    RecipeName = "CHILI BEAN-AND-BULGUR CAKES",
                    Ingredients = "½ cup whole-kernel bulgur wheat, 2 Tbsp vegetable oil, 1 Tbsp tomato paste, " +
                                     "1 tsp chili powder, ½ tsp ground cumin, Large pinch cayenne pepper, ¼ cup reduced - fat sour cream, " +
                                     "Zest and juice of 1 lime, Kosher salt, 1 15 - oz can kidney beans, drained and rinsed",
                    Process = "1. Combine the bulgur with 1 1/2 cups of water in a small saucepan. Bring to a boil, " +
                                     "reduce heat to medium low, cover and simmer until tender, 10 to 12 minutes." +
                                     " Drain off the excess water and cool the bulgur completely. " +
                                     "2.Heat the oil in a small skillet over medium - high heat.Add the tomato paste, chili powder," +
                                     "cumin and cayenne and whisk until the oil is yellow and the spices are fragrant," +
                                     "about 45 seconds.Remove from the heat and let the chili oil cool to room temperature. " +
                                     "3.Whisk together the sour cream, lime zest and juice, a pinch of salt and 1 tablespoon water in a small bowl." +
                                     "Refrigerate until ready to serve. " +
                                     "4.Position an oven rack at the top of the oven and preheat the broiler.Line a baking sheet with foil." +
                                     "Combine the beans, cooked bulgur, cheese"

                    //Price = 34.95m
                }

             );

                context.SaveChanges();
            }
            
        }
    }
}
