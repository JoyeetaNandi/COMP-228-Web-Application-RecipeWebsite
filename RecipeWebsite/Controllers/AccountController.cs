using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RecipeWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace RecipeWebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, 
            SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;

        }



        //[HttpGet]
        //public IActionResult Login(String returnUrl)
        //{
        //    UserModel user = new UserModel {
        //        ReturnUrl = returnUrl
        //    };
        //    return View(user);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Login(UserModel userModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityUser user = await userManager.FindByNameAsync(userModel.Name);
        //        if ((user != null) && (await signInManager.PasswordSignInAsync(user,userModel.Password, false, false)).Succeeded)
        //        {
        //            if(string.IsNullOrEmpty(userModel?.ReturnUrl))
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                return Redirect(userModel?.ReturnUrl);
        //            }                    
        //        }
        //    }
        //    return View(userModel);
        //}


        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new UserModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(userModel.Name);

                if (user != null)
                {
                    if ((await signInManager.PasswordSignInAsync(user,
                        userModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(userModel?.ReturnUrl ?? "/Home/Index");
                    }

                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(userModel);
        }
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}