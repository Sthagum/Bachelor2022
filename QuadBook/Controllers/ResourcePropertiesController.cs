#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuadBook.Data;
using QuadBook.Models;

namespace QuadBook.Controllers
{
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
            var applicationDbContext = _context.ResourceProperties.Include(r => r.TypeProperties);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResourceProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperties = await _context.ResourceProperties
                .Include(r => r.TypeProperties)
                .FirstOrDefaultAsync(m => m.resourcePropertiesId == id);
            if (resourceProperties == null)
            {
                return NotFound();
            }

            return View(resourceProperties);
        }

        // GET: ResourceProperties/Create
        public IActionResult Create()
        {
            ViewData["typePropertiesId"] = new SelectList(_context.Set<TypeProperties>(), "typePropertiesId", "typePropertiesId");
            return View();
        }

        // POST: ResourceProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("resourcePropertiesId,value,typePropertiesId")] ResourceProperties resourceProperties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["typePropertiesId"] = new SelectList(_context.Set<TypeProperties>(), "typePropertiesId", "typePropertiesId", resourceProperties.typePropertiesId);
            return View(resourceProperties);
        }

        // GET: ResourceProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperties = await _context.ResourceProperties.FindAsync(id);
            if (resourceProperties == null)
            {
                return NotFound();
            }
            ViewData["typePropertiesId"] = new SelectList(_context.Set<TypeProperties>(), "typePropertiesId", "typePropertiesId", resourceProperties.typePropertiesId);
            return View(resourceProperties);
        }

        // POST: ResourceProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("resourcePropertiesId,value,typePropertiesId")] ResourceProperties resourceProperties)
        {
            if (id != resourceProperties.resourcePropertiesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcePropertiesExists(resourceProperties.resourcePropertiesId))
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
            ViewData["typePropertiesId"] = new SelectList(_context.Set<TypeProperties>(), "typePropertiesId", "typePropertiesId", resourceProperties.typePropertiesId);
            return View(resourceProperties);
        }

        // GET: ResourceProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceProperties = await _context.ResourceProperties
                .Include(r => r.TypeProperties)
                .FirstOrDefaultAsync(m => m.resourcePropertiesId == id);
            if (resourceProperties == null)
            {
                return NotFound();
            }

            return View(resourceProperties);
        }

        // POST: ResourceProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceProperties = await _context.ResourceProperties.FindAsync(id);
            _context.ResourceProperties.Remove(resourceProperties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourcePropertiesExists(int id)
        {
            return _context.ResourceProperties.Any(e => e.resourcePropertiesId == id);
        }
    }
}
