using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpiritLink.Models;

namespace SpiritLink.Controllers
{
    [Authorize]
    public class LaySchoolsController : Controller
    {
        private readonly AtonsuDbContext _context;

        public LaySchoolsController(AtonsuDbContext context)
        {
            _context = context;
        }

        // GET: LaySchools
        public async Task<IActionResult> Index()
        {
            var atonsuDbContext = _context.LaySchools.Include(l => l.BacentaLeader).Include(l => l.Member).Include(l => l.PastorNameNavigation);
            return View(await atonsuDbContext.ToListAsync());
        }

        // GET: LaySchools/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laySchool = await _context.LaySchools
                .Include(l => l.BacentaLeader)
                .Include(l => l.Member)
                .Include(l => l.PastorNameNavigation)
                .FirstOrDefaultAsync(m => m.SchoolName == id);
            if (laySchool == null)
            {
                return NotFound();
            }

            return View(laySchool);
        }

        // GET: LaySchools/Create
        public IActionResult Create()
        {
            ViewData["LeaderName"] = new SelectList(_context.BacentaLeaders, "LeaderName", "LeaderName");
            ViewData["MemberName"] = new SelectList(_context.Members, "MemberName", "MemberName");
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName");
            return View();
        }

        // POST: LaySchools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolName,SchoolId,PastorName,MemberName,ConvertName,FirstTimerName,LeaderId,LeaderName,MemberId,Date")] LaySchool laySchool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laySchool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaderName"] = new SelectList(_context.BacentaLeaders, "LeaderName", "LeaderName", laySchool.LeaderName);
            ViewData["MemberName"] = new SelectList(_context.Members, "MemberName", "MemberName", laySchool.MemberName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", laySchool.PastorName);
            return View(laySchool);
        }

        // GET: LaySchools/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laySchool = await _context.LaySchools.FindAsync(id);
            if (laySchool == null)
            {
                return NotFound();
            }
            ViewData["LeaderName"] = new SelectList(_context.BacentaLeaders, "LeaderName", "LeaderName", laySchool.LeaderName);
            ViewData["MemberName"] = new SelectList(_context.Members, "MemberName", "MemberName", laySchool.MemberName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", laySchool.PastorName);
            return View(laySchool);
        }

        // POST: LaySchools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SchoolName,SchoolId,PastorName,MemberName,ConvertName,FirstTimerName,LeaderId,LeaderName,MemberId,Date")] LaySchool laySchool)
        {
            if (id != laySchool.SchoolName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laySchool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaySchoolExists(laySchool.SchoolName))
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
            ViewData["LeaderName"] = new SelectList(_context.BacentaLeaders, "LeaderName", "LeaderName", laySchool.LeaderName);
            ViewData["MemberName"] = new SelectList(_context.Members, "MemberName", "MemberName", laySchool.MemberName);
            ViewData["PastorName"] = new SelectList(_context.Pastors, "PastorName", "PastorName", laySchool.PastorName);
            return View(laySchool);
        }

        // GET: LaySchools/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laySchool = await _context.LaySchools
                .Include(l => l.BacentaLeader)
                .Include(l => l.Member)
                .Include(l => l.PastorNameNavigation)
                .FirstOrDefaultAsync(m => m.SchoolName == id);
            if (laySchool == null)
            {
                return NotFound();
            }

            return View(laySchool);
        }

        // POST: LaySchools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var laySchool = await _context.LaySchools.FindAsync(id);
            if (laySchool != null)
            {
                _context.LaySchools.Remove(laySchool);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaySchoolExists(string id)
        {
            return _context.LaySchools.Any(e => e.SchoolName == id);
        }
    }
}
