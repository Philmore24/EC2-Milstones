using EC2_1701497.Models;
using EC2_1701497.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.Controllers
{
    public class AccountController : Controller
    {

        public  UserManager<ApplicationUser> userManager { get; }

        public SignInManager<ApplicationUser> signInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var CheckEmail = await userManager.FindByEmailAsync(model.Email);
                if (CheckEmail == null)
                {

                    var user = new ApplicationUser {
                        UserName = model.Email,
                        Email = model.Email,
                        Firstname = model.Firstname,
                        Lastname = model.Lastname,
                    };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {

                       // await userManager.AddToRoleAsync(user, "Customer");
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email already exits");
                }

               
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);

            if (user == null) //if user is null
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {Email} is already in use");
            }
        }




    }
}
