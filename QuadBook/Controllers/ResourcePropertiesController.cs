#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuadBook.Data;
using QuadBook.Models;

namespace QuadBook.Controllers
{
    [Authorize]
    public class ResourcePropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcePropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResourceProperties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResourceProperty.Include(r => r.TypeProperty);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResourceProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperty = await _context.ResourceProperty
                .Include(r => r.TypeProperty)
                .FirstOrDefaultAsync(m => m.ResourcePropertyID == id);
            if (resourceProperty == null)
            {
                return NotFound();
            }

            return View(resourceProperty);
        }

        // GET: ResourceProperties/Create
        public IActionResult Create()
        {
            ViewData["TypePropertyID"] = new SelectList(_context.TypeProperties, "TypePropertyID", "TypePropertyName");
            return View();
        }

        // POST: ResourceProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourcePropertyID,ResourcePropertyValue,TypePropertyID")] ResourceProperty resourceProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypePropertyID"] = new SelectList(_context.TypeProperties, "TypePropertyID", "TypePropertyName", resourceProperty.TypePropertyID);
            return View(resourceProperty);
        }

        // GET: ResourceProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperty = await _context.ResourceProperty.FindAsync(id);
            if (resourceProperty == null)
            {
                return NotFound();
            }
            ViewData["TypePropertyID"] = new SelectList(_context.TypeProperties, "TypePropertyID", "TypePropertyName", resourceProperty.TypePropertyID);
            return View(resourceProperty);
        }

        // POST: ResourceProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourcePropertyID,ResourcePropertyValue,TypePropertyID")] ResourceProperty resourceProperty)
        {
            if (id != resourceProperty.ResourcePropertyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcePropertyExists(resourceProperty.ResourcePropertyID))
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
            ViewData["TypePropertyID"] = new SelectList(_context.TypeProperties, "TypePropertyID", "TypePropertyName", resourceProperty.TypePropertyID);
            return View(resourceProperty);
        }

        // GET: ResourceProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperty = await _context.ResourceProperty
                .Include(r => r.TypeProperty)
                .FirstOrDefaultAsync(m => m.ResourcePropertyID == id);
            if (resourceProperty == null)
            {
                return NotFound();
            }

            return View(resourceProperty);
        }

        // POST: ResourceProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceProperty = await _context.ResourceProperty.FindAsync(id);
            _context.ResourceProperty.Remove(resourceProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourcePropertyExists(int id)
        {
            return _context.ResourceProperty.Any(e => e.ResourcePropertyID == id);
        }
    }
}
