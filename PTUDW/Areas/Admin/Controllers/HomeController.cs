using Microsoft.AspNetCore.Mvc;
using PTUDW.Utilities;

namespace PTUDW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }

        public IActionResult Logout()
        {
            Function._AccountId = 0;
            Function._Username = string.Empty;
            Function._Message = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}
