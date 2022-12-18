using DTO.DTOs.DashboardDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppinglist_BusinessLayer.Concrete;
using Shoppinglist_DAL.EntityFramework;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        ProductManager productManager = new ProductManager(new EFProductDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            DashboardDto dashboardDto = new DashboardDto() {
                ActiveProductCount = productManager.TList(x=>x.Status==true).Count(),
                PassiveProductCount = productManager.TList(x=>x.Status==false).Count(),
                CategoryCount=categoryManager.TList().Count()
            };
            return View(dashboardDto);
        }
    }
}
