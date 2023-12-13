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
    public class NewConvertsController : Controller
    {
        private readonly AtonsuDbContext _context;

        public NewConvertsController(AtonsuDbContext context)
        {
            _context = context;
        }

        // GET: NewConverts
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewConverts.ToListAsync());
        }

        // GET: NewConverts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newConvert = await _context.NewConverts
                .FirstOrDefaultAsync(m => m.ConvertName == id);
            if (newConvert == null)
            {
                return NotFound();
            }

            return View(newConvert);
        }

        // GET: NewConverts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewConverts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConvertName,PhoneNumber,Gpsaddress,Status,Location,WhoInvited,AreaDescription,Date")] NewConvert newConvert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newConvert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newConvert);
        }

        // GET: NewConverts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newConvert = await _context.NewConverts.FindAsync(id);
            if (newConvert == null)
            {
                return NotFound();
            }
            return View(newConvert);
        }

        // POST: NewConverts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConvertName,PhoneNumber,Gpsaddress,Status,Location,WhoInvited,AreaDescription,Date")] NewConvert newConvert)
        {
            if (id != newConvert.ConvertName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newConvert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewConvertExists(newConvert.ConvertName))
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
            return View(newConvert);
        }

        // GET: NewConverts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newConvert = await _context.NewConverts
                .FirstOrDefaultAsync(m => m.ConvertName == id);
            if (newConvert == null)
            {
                return NotFound();
            }

            return View(newConvert);
        }

        // POST: NewConverts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var newConvert = await _context.NewConverts.FindAsync(id);
            if (newConvert != null)
            {
                _context.NewConverts.Remove(newConvert);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewConvertExists(string id)
        {
            return _context.NewConverts.Any(e => e.ConvertName == id);
        }
    }
}
