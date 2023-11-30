using Microsoft.AspNetCore.Mvc;
using PTUDW.Models;
using PTUDW.Utilities;

namespace PTUDW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly HarmicContext _context;

        public LoginController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TbAccount account)
        {
            if(account == null)
            {
                return NotFound();
            }
            string password = HashMD5.GetHash(account.Password);
            var check = _context.TbAccounts.Where(m => m.Username == account.Username && m.Password == password).FirstOrDefault();
            if(check == null)
            {
                Function._Message = "Invalid Username or Password";
                return RedirectToAction("Index", "Login");
            }
            Function._Message = string.Empty;
            Function._AccountId = check.AccountId;
            Function._Username = check.Username;
            return RedirectToAction("Index", "Home");
        }
    }
}
