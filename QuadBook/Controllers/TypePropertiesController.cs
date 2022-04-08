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
    public class TypePropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypePropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeProperties.ToListAsync());
        }

        // GET: TypeProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperties = await _context.TypeProperties
                .FirstOrDefaultAsync(m => m.typePropertiesId == id);
            if (typeProperties == null)
            {
                return NotFound();
            }

            return View(typeProperties);
        }

        // GET: TypeProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("typePropertiesId,name")] TypeProperties typeProperties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProperties);
        }

        // GET: TypeProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperties = await _context.TypeProperties.FindAsync(id);
            if (typeProperties == null)
            {
                return NotFound();
            }
            return View(typeProperties);
        }

        // POST: TypeProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("typePropertiesId,name")] TypeProperties typeProperties)
        {
            if (id != typeProperties.typePropertiesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePropertiesExists(typeProperties.typePropertiesId))
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
            return View(typeProperties);
        }

        // GET: TypeProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperties = await _context.TypeProperties
                .FirstOrDefaultAsync(m => m.typePropertiesId == id);
            if (typeProperties == null)
            {
                return NotFound();
            }

            return View(typeProperties);
        }

        // POST: TypeProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeProperties = await _context.TypeProperties.FindAsync(id);
            _context.TypeProperties.Remove(typeProperties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypePropertiesExists(int id)
        {
            return _context.TypeProperties.Any(e => e.typePropertiesId == id);
        }
    }
}
