using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList_UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
