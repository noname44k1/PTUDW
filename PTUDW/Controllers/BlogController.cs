using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;
using System.Configuration;
using X.PagedList;

namespace PTUDW.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;
        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            var blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogId).ToPagedList((int)page, pageSize);
            ViewBag.blogComment = _context.TbBlogComments.ToList();
            return View(blogs);
        }

        [Route("/blog/{alias}-{id}.html")]
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
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Create(int? id, string name, string phone, string email, string message)
        {
            try
            {
                TbBlogComment comment = new TbBlogComment();
                comment.BlogId = id;
                comment.Name = name;
                comment.Phone = phone;
                comment.Email = email;
                comment.Detail = message;
                comment.CreatedDate = DateTime.Now;
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
