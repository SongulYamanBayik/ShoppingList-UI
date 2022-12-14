using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.EntityFramework;

namespace ShoppingList_UI.Controllers
{
    public class ProductToDoListController : Controller
    {
        ProductToDoManager productToDoManager = new ProductToDoManager(new EFProductToDoListDal());
        public IActionResult Index(int id)
        {
            var value=productToDoManager.TGetByID(id);


            return View(value);
        }
    }
}
