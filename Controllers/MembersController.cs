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
    public class MembersController : Controller
    {
        private readonly AtonsuDbContext _context;

        public MembersController(AtonsuDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var atonsuDbContext = _context.Members.Include(m => m.ConvertNameNavigation).Include(m => m.FirstTimerNameNavigation).Include(m => m.PastorNameNavigation);
            return View(await atonsuDbContext.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.ConvertNameNavigation)
                .Include(m => m.FirstTimerNameNavigation)
                .Include(m => m.PastorNameNavigation)
                .FirstOrDefaultAsync(m => m.MemberName == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewData["ConvertName"] = new SelectList(_context.NewConverts, "ConvertName", "ConvertName");
            ViewData["FirstTimerName"] = new SelectList(_context.FirstTimers, "FirstTimerName", "FirstTimerName");
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberName,PastorName,ConvertName,FirstTimerName,PhoneNumber,ActiveStatus,Gpsaddress,Basonta,Location,AreaDescription")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConvertName"] = new SelectList(_context.NewConverts, "ConvertName", "ConvertName", member.ConvertName);
            ViewData["FirstTimerName"] = new SelectList(_context.FirstTimers, "FirstTimerName", "FirstTimerName", member.FirstTimerName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", member.PastorName);
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["ConvertName"] = new SelectList(_context.NewConverts, "ConvertName", "ConvertName", member.ConvertName);
            ViewData["FirstTimerName"] = new SelectList(_context.FirstTimers, "FirstTimerName", "FirstTimerName", member.FirstTimerName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", member.PastorName);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MemberName,PastorName,ConvertName,FirstTimerName,PhoneNumber,ActiveStatus,Gpsaddress,Basonta,Location,AreaDescription")] Member member)
        {
            if (id != member.MemberName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberName))
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
            ViewData["ConvertName"] = new SelectList(_context.NewConverts, "ConvertName", "ConvertName", member.ConvertName);
            ViewData["FirstTimerName"] = new SelectList(_context.FirstTimers, "FirstTimerName", "FirstTimerName", member.FirstTimerName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", member.PastorName);
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.ConvertNameNavigation)
                .Include(m => m.FirstTimerNameNavigation)
                .Include(m => m.PastorNameNavigation)
                .FirstOrDefaultAsync(m => m.MemberName == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(string id)
        {
            return _context.Members.Any(e => e.MemberName == id);
        }
    }
}
