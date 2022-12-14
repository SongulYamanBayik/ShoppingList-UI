using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class ToDoListController : Controller
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());
        public IActionResult Index()
        {
            var value = toDoListManager.TList();
            return View(value);
        }

        public JsonResult AddToDoList(string ToDoListName)
        {
            ToDoList toDoList = new ToDoList() 
            {
                Name=ToDoListName
            };

            toDoListManager.TInsert(toDoList);
            return Json(true);
        }

    }
}
