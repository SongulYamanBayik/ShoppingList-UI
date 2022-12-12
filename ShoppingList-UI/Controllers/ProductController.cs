using AutoMapper;
using DTO.DTOs.ProductDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_BusinessLayer.ValidationRules.ProductValidator;
using Shoppinglist_BusinessLayer.ValidationRules.ProductValidator.ProductValidator;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        ProductManager productManager = new ProductManager(new EFProductDal());

        Context context = new Context();

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = productManager.TList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.SelectListCategory = context.Categories.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddDto productAddDto)
        {
            productAddDto.NormalizedName = productAddDto.Name.ToUpper();

            Product product = _mapper.Map<Product>(productAddDto);


            ProductAddValidator validationRules = new ProductAddValidator();
            ValidationResult result = validationRules.Validate(productAddDto);

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
        public IActionResult EditeProduct(ProductUpdateDto productUpdateDto)
        {
            Product product = _mapper.Map<Product>(productUpdateDto);

            ProductUpdateValidator validationRules = new ProductUpdateValidator();
            ValidationResult result = validationRules.Validate(productUpdateDto);

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
