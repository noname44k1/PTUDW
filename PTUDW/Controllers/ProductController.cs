using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;

namespace PTUDW.Controllers
{
    public class ProductController : Controller
    {
        private readonly HarmicContext _context;
        public ProductController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProducts == null)
            {
                return NotFound();
            }

            var product = await _context.TbProducts.Include(i=>i.CategoryProduct)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReview = _context.TbProductReviews.Where(i=>i.ProductId == id && i.IsActive).ToList();
            ViewBag.productRelated = _context.TbProducts.Where(i=>i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5).OrderByDescending(i=>i.ProductId).ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(int? id, string name, string phone, string email, string message)
        {
            try
            {
                TbProductReview comment = new TbProductReview();
                comment.ProductId = id;
                comment.Name = name;
                comment.Phone = phone;
                comment.Email = email;
                comment.Detail = message;
                comment.CreatedDate = DateTime.Now;
                comment.Star = 5;
                comment.IsActive = true;
                _context.Add(comment);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
