using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Controllers
{
    public class PictureController : Controller
    {
        private IRecipeRepository repository;
        public PictureController(IRecipeRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Picture(int recipeId)
        {
            return View("Image" ,new UploadImages
            {
                RecipeId = recipeId
            });
        }
        [HttpPost]
        public IActionResult Picture(UploadImages upimage, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                //string ext = Path.GetExtension(image.FileName).ToLower();
                //if(ext == ".jpg" || ext == ".png")
                //{
                  //  if (image.Length > 0)
                    //{
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            upimage.Image = fileBytes;
                        }
                    //}                    
                    repository.AddUploadedImage(upimage);
                    return RedirectToAction("RecipeList", "Home", repository.Recipes);
                //}

            }
            ModelState.AddModelError("", "Invalid file Extension");
            return View("Image", image);
        }

        //[HttpPost("FileUpload")]
        //public async Task<IActionResult> Image(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    var filePaths = new List<string>();
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            // full path to file in temp location
        //            var filePath = "C:/files"; // Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
        //            filePaths.Add(filePath);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    // process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size, filePaths });
        //}
    }
}
