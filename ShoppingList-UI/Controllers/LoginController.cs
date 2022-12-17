using DTO.DTOs.UserDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Shoppinglist_BusinessLayer.ValidationRules.UserValidator;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInDto user)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByEmailAsync(user.Email);
                if (appUser != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, user.Password, false, false);

                    if (result.Succeeded)
                    {
                        System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                        var roles = await _userManager.GetRolesAsync(appUser);
                        if (roles.Contains("User"))
                        {
                            return Redirect("/TodoList/Index");
                        }
                        return Redirect("/Role/Index");


                    }
                }
                ModelState.AddModelError(nameof(user.Email), "Login Failed: Invalid Email or password");
            }
            return View("Index");
            //UserSignInValidator validationRules = new UserSignInValidator();
            //ValidationResult result = validationRules.Validate(user);


            //if (ModelState.IsValid)
            //{

            //    var result1 = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
            //    if (result1.Succeeded)
            //    {

            //        return RedirectToAction("Index", "Role");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Kullanıcı Adı yada Şifre Hatalı");
            //    }
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError("", item.ErrorMessage);
            //    }
            //}
            //return View();
        }
    }
}
