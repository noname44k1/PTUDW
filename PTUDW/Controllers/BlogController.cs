using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;

namespace PTUDW.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;
        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).ToListAsync();
            return View(await blogs);
        }

        [Route("/blog/{alias}-{id}.html", Name = "Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TbBlogs
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(i=>i.BlogId == id).ToList();
            return View(blog);
        }
    }
}
