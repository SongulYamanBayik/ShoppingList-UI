using AutoMapper;
using DTO.DTOs.UserDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.ValidationRules.UserValidator;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpDto user)
        {
            UserSignUpValidator validationRules = new UserSignUpValidator();
            ValidationResult result = validationRules.Validate(user);


            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Surname = user.Surname;
                appUser.Email = user.email;
                appUser.Name = user.Name;
                appUser.UserName = user.UserName;

                var result1= await _userManager.CreateAsync(appUser, user.Password);
                if (result1.Succeeded)
                {
                    var res =await _userManager.AddToRoleAsync(appUser, "User");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result1.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }
                }
            return View();
        }
       
    }
}
