using AutoMapper;
using DTO.DTOs.ProductToDoListDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    [Authorize]
    public class ProductToDoListController : Controller
    {
       
        ProductToDoManager productToDoManager = new ProductToDoManager(new EFProductToDoListDal());
        ProductManager productManager = new ProductManager(new EFProductDal());
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());
        Context context = new Context();

        public IActionResult Index(int id)
        {
            ProductToDoListDto productToDoListDto = new ProductToDoListDto()
            {
                products = productManager.TList(x=> x.Status==true),
                selectedListItems = productToDoManager.TGetToDoListByListID(x => x.ToDoListID==id),
                toDoLists=toDoListManager.TList(x=>x.ID==id),
                toDoListID = id
              
            };

            return View(productToDoListDto);
        }

        public IActionResult AddProductToDoList(AddProductToDoListDTO addProductToDoListDTO)
        {
            ProductToDoList a = new ProductToDoList() {
                ProductID =addProductToDoListDTO.productID,
                ToDoListID = addProductToDoListDTO.toDoListID,
                Description = addProductToDoListDTO.description
            };
            productToDoManager.TInsert(a);

            return Json("OK");
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
