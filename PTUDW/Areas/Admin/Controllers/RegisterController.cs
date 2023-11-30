using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;
using PTUDW.Utilities;
using System.Security.Cryptography;

namespace PTUDW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly HarmicContext _context;

        public RegisterController(HarmicContext context)
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
            if(account == null) { return NotFound(); }

            var check = _context.TbAccounts.Where(m => m.Username == account.Username).FirstOrDefault();
            if (check != null)
            {
                Function._Message = "Trùng tài khoản";
                return RedirectToAction("Index", "Register");
            }
            Function._Message = string.Empty;
            account.Password = HashMD5.GetHash(account.Password != null ? account.Password : "");
            _context.Add(account);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
