using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_BusinessLayer.ValidationRules;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EFProductDal());

        Context context = new Context();
        public IActionResult Index()
        {
            var values = productManager.TList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            product.NormalizedName = product.Name.ToUpper();

            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);

            if (result.IsValid)
            {
                productManager.TInsert(product);
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

        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.TGetByID(id);
            value.Status = false;
            productManager.TDeleteByStatus(value);
            return RedirectToAction("Index");
        }
        public IActionResult ActivateProduct(int id)
        {
            var value = productManager.TGetByID(id);
            value.Status = true;
            productManager.TDeleteByStatus(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditeProduct(int id)
        {
            var values = productManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditeProduct(Product product)
        {
            ProductUpdateValidator validationRules = new ProductUpdateValidator();
            ValidationResult result = validationRules.Validate(product);

            if (result.IsValid)
            {
                product.NormalizedName = product.Name.ToUpper();
                productManager.TUpdate(product);
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
