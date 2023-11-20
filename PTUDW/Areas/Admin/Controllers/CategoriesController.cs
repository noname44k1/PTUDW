using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTUDW.Models;

namespace PTUDW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly HarmicContext _context;

        public CategoriesController(HarmicContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
              return _context.TbCategories != null ? 
                          View(await _context.TbCategories.ToListAsync()) :
                          Problem("Entity set 'HarmicContext.TbCategories'  is null.");
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbCategories == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbCategory == null)
            {
                return NotFound();
            }

            return View(tbCategory);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Title,Alias,Description,Position,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] TbCategory tbCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCategory);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbCategories == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories.FindAsync(id);
            if (tbCategory == null)
            {
                return NotFound();
            }
            return View(tbCategory);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Title,Alias,Description,Position,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] TbCategory tbCategory)
        {
            if (id != tbCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCategoryExists(tbCategory.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbCategory);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbCategories == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbCategory == null)
            {
                return NotFound();
            }

            return View(tbCategory);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public bool DeleteConfirmed(int id)
        {
            try
            {
                if (_context.TbCategories == null)
                {
                    return false;
                }
                var tbCategory = _context.TbCategories.Find(id);
                if (tbCategory != null)
                {
                    _context.TbCategories.Remove(tbCategory);
                }

                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private bool TbCategoryExists(int id)
        {
          return (_context.TbCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
