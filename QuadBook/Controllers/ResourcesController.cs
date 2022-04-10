﻿#nullable disable
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
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resources
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resource.Include(r => r.Location).Include(r => r.ResourceProperties).Include(r => r.ResourceType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .Include(r => r.Location)
                .Include(r => r.ResourceProperties)
                .Include(r => r.ResourceType)
                .FirstOrDefaultAsync(m => m.resourceId == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Create
        public IActionResult Create()
        {
            ViewData["locationId"] = new SelectList(_context.Location, "LocationID", "LocationID");
            ViewData["resourcePropertiesID"] = new SelectList(_context.Set<ResourceProperties>(), "resourcePropertiesId", "resourcePropertiesId");
            ViewData["ResourceTypeID"] = new SelectList(_context.Set<ResourceType>(), "resourceTypeId", "resourceTypeId");
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("resourceId,resourceName,locationId,resourcePropertiesID,ResourceTypeID")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationId"] = new SelectList(_context.Location, "LocationID", "LocationID", resource.locationId);
            ViewData["resourcePropertiesID"] = new SelectList(_context.Set<ResourceProperties>(), "resourcePropertiesId", "resourcePropertiesId", resource.resourcePropertiesID);
            ViewData["ResourceTypeID"] = new SelectList(_context.Set<ResourceType>(), "resourceTypeId", "resourceTypeId", resource.ResourceTypeID);
            return View(resource);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            ViewData["locationId"] = new SelectList(_context.Location, "LocationID", "LocationID", resource.locationId);
            ViewData["resourcePropertiesID"] = new SelectList(_context.Set<ResourceProperties>(), "resourcePropertiesId", "resourcePropertiesId", resource.resourcePropertiesID);
            ViewData["ResourceTypeID"] = new SelectList(_context.Set<ResourceType>(), "resourceTypeId", "resourceTypeId", resource.ResourceTypeID);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("resourceId,resourceName,locationId,resourcePropertiesID,ResourceTypeID")] Resource resource)
        {
            if (id != resource.resourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceExists(resource.resourceId))
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
            ViewData["locationId"] = new SelectList(_context.Location, "LocationID", "LocationID", resource.locationId);
            ViewData["resourcePropertiesID"] = new SelectList(_context.Set<ResourceProperties>(), "resourcePropertiesId", "resourcePropertiesId", resource.resourcePropertiesID);
            ViewData["ResourceTypeID"] = new SelectList(_context.Set<ResourceType>(), "resourceTypeId", "resourceTypeId", resource.ResourceTypeID);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .Include(r => r.Location)
                .Include(r => r.ResourceProperties)
                .Include(r => r.ResourceType)
                .FirstOrDefaultAsync(m => m.resourceId == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Resource.FindAsync(id);
            _context.Resource.Remove(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceExists(int id)
        {
            return _context.Resource.Any(e => e.resourceId == id);
        }
    }
}
