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
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Booking.Include(b => b.Resource);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resources
        public async Task<IActionResult> BookResource(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            var resources = from r in _context.Resource.Include(r => r.ResourceType).Include(r => r.Location)
                            select r;
            switch (sortOrder)
            {
                case "name_desc":
                    resources = resources.OrderByDescending(r => r.ResourceName);
                    break;
                case "type_desc":
                    resources = resources.OrderBy(r => r.ResourceType);
                    break;
            }
            return View(await resources.AsNoTracking().ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Resource)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [Authorize]

        public async Task<IActionResult> UserBookings()
        {
            var applicationDbContext = _context.Booking.Include(b => b.Resource)
            .Where(g => g.UserEmail == User.Identity.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ResourceID"] = new SelectList(_context.Resource, "ID", "ResourceName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserEmail,StartDate,EndDate,ResourceID")] Booking booking)
        {
            var applicationDbContext = _context.Booking.Include(b => b.Resource);

            foreach (Booking b in applicationDbContext)
            {
                if (b.ResourceID == booking.ResourceID)
                {
                    if (((booking.StartDate < b.StartDate) && (booking.EndDate <= b.StartDate)) ||
                       ((booking.StartDate >= b.EndDate) && (booking.EndDate > b.EndDate)))
                    {
                        continue;
                    }

                    else
                    {
                        TempData["DateTaken"] = "Ressursen er opptatt denne perioden, vennligst velg annen dato.";
                        return RedirectToPage("/Bookings/Create");
                    }

                }
            }
            if (ModelState.IsValid) {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserBookings));
            }

            ViewData["ResourceID"] = new SelectList(_context.Resource, "ID", "ResourceName", booking.ResourceID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ResourceID"] = new SelectList(_context.Resource, "ID", "ResourceName", booking.ResourceID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserEmail,StartDate,EndDate,ResourceID")] Booking booking)
        {
            if (id != booking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.ID))
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
            ViewData["ResourceID"] = new SelectList(_context.Resource, "ID", "ResourceName", booking.ResourceID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Resource)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserBookings));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }
    }
}
