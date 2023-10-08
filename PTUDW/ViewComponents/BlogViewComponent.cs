using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;

namespace PTUDW.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly HarmicContext _context;

        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive).Take(5).ToList();
            ViewBag.blogComment = _context.TbBlogComments.ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
