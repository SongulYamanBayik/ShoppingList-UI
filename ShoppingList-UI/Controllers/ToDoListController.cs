using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ToDoListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());
       
        public IActionResult Index()
        {
            var users = _userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserMail = users.Result.Email;
            var userId = users.Result.Id;
            //var ue = _userManager.GetUserIdAsync(users);
            var value = toDoListManager.TList(x=> x.AppUserID == userId);

            return View(value);
        }

        public JsonResult AddToDoList(string ToDoListName)
        {
            var users = _userManager.GetUserAsync(HttpContext.User);
            ToDoList toDoList = new ToDoList()
            {
                Name = ToDoListName,
                AppUserID = users.Result.Id
            };

            toDoListManager.TInsert(toDoList);
            return Json(true);
        }

        public IActionResult DeleteToDoList(int id)
        {
            var value = toDoListManager.TGetByID(id);
            toDoListManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public JsonResult UpdateToDoList(int id, string ToDoListName)
        {
            var model = toDoListManager.TGetByID(id);
            model.Name = ToDoListName;
            toDoListManager.TUpdate(model);
            return Json(true);
        }

    }
}
