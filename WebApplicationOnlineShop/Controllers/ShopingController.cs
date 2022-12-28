using Microsoft.AspNetCore.Mvc;
using WebApplicationOnlineShop.Logic;
using WebApplicationOnlineShop.Models;

namespace WebApplicationOnlineShop.Controllers
{
    public class ShopingController : Controller
    {
        [HttpGet]
        public IActionResult InsertOperation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertOperation(Product obj)
        {


            if (ModelState.IsValid)
            {
                bool res = Business_logic.Insertdata(obj);

                if (res == true)
                {
                    return View(obj); /*return RedirectToAction("Login");*/
                   
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return View(obj);
            }
        }
    }
}
