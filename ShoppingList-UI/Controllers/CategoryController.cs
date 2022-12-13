using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_BusinessLayer.ValidationRules.CategoryValidator;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var value = categoryManager.TList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.NormalizedName = category.Name.ToUpper();
            CategoryAddValidator validationRules = new CategoryAddValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                categoryManager.TInsert(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorCode);
                }
                return View();

            }

        }

        public IActionResult PassiveCategory(int id)
        {
            var value = categoryManager.TGetByID(id);
            value.Status = false;
            categoryManager.TDeleteByStatus(value);
            return RedirectToAction("Index");
        } 
        public IActionResult ActiveCategory(int id)
        {
            var value = categoryManager.TGetByID(id);
            value.Status = true;
            categoryManager.TDeleteByStatus(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var value = categoryManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            CategoryUpdateValidator validationRules = new CategoryUpdateValidator();
            ValidationResult result=validationRules.Validate(category);
            if (result.IsValid)
            {
                category.NormalizedName = category.Name.ToUpper();
                categoryManager.TUpdate(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();

            }
        }
    }
}
