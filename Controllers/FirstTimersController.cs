using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpiritLink.Models;

namespace SpiritLink.Controllers
{
    public class FirstTimersController : Controller
    {
        private readonly AtonsuDbContext _context;

        public FirstTimersController(AtonsuDbContext context)
        {
            _context = context;
        }

        // GET: FirstTimers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirstTimers.ToListAsync());
        }

        // GET: FirstTimers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstTimer = await _context.FirstTimers
                .FirstOrDefaultAsync(m => m.FirstTimerName == id);
            if (firstTimer == null)
            {
                return NotFound();
            }

            return View(firstTimer);
        }

        // GET: FirstTimers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FirstTimers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstTimerName,PhoneNumber,GpsAddress,Status,Location,WhoInvited,AreaDescription,Date")] FirstTimer firstTimer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firstTimer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firstTimer);
        }

        // GET: FirstTimers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstTimer = await _context.FirstTimers.FindAsync(id);
            if (firstTimer == null)
            {
                return NotFound();
            }
            return View(firstTimer);
        }

        // POST: FirstTimers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstTimerName,PhoneNumber,GpsAddress,Status,Location,WhoInvited,AreaDescription,Date")] FirstTimer firstTimer)
        {
            if (id != firstTimer.FirstTimerName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firstTimer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirstTimerExists(firstTimer.FirstTimerName))
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
            return View(firstTimer);
        }

        // GET: FirstTimers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstTimer = await _context.FirstTimers
                .FirstOrDefaultAsync(m => m.FirstTimerName == id);
            if (firstTimer == null)
            {
                return NotFound();
            }

            return View(firstTimer);
        }

        // POST: FirstTimers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var firstTimer = await _context.FirstTimers.FindAsync(id);
            if (firstTimer != null)
            {
                _context.FirstTimers.Remove(firstTimer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirstTimerExists(string id)
        {
            return _context.FirstTimers.Any(e => e.FirstTimerName == id);
        }
    }
}
