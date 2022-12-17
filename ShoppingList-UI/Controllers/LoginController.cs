using DTO.DTOs.UserDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.ValidationRules.UserValidator;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInDto user)
        {
            UserSignInValidator validationRules = new UserSignInValidator();
            ValidationResult result = validationRules.Validate(user);


            if (ModelState.IsValid)
            {
               
                var result1 = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
                if (result1.Succeeded)
                {
                   
                    return RedirectToAction("Index", "ToDoList");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı yada Şifre Hatalı");
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
