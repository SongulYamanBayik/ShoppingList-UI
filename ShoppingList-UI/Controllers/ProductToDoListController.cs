using AutoMapper;
using DTO.DTOs.ProductToDoListDTOs;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class ProductToDoListController : Controller
    {
       
        ProductToDoManager productToDoManager = new ProductToDoManager(new EFProductToDoListDal());
        ProductManager productManager = new ProductManager(new EFProductDal());
        Context context = new Context();

        public IActionResult Index(int id)
        {
            ProductToDoListDto productToDoListDto = new ProductToDoListDto()
            {
                products = productManager.TList(x=> x.Status==true),
                selectedListItems = productToDoManager.TGetToDoListByListID(x => x.ToDoListID==id)
            };

            return View(productToDoListDto);
        }

        public PartialViewResult Index2()
        {
            var value = productManager.TList();
            return PartialView(value);
        }

        [HttpGet]
        public IActionResult EditProductToDoList(int id)
        {
            var value = productToDoManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditProductToDoList(ProductToDoList productToDoList)
        {
            productToDoManager.TUpdate(productToDoList);
            return RedirectToAction("Index","ToDoList");
        }

        public IActionResult DeleteProductToDoList(int id)
        {
            var value = productToDoManager.TGetByID(id);
            productToDoManager.TDelete(value);
            return RedirectToAction("Index", "ToDoList");
        }
    }
}
