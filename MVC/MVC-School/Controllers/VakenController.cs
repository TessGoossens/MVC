using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_School.Data;
using MVC_School.Models;

namespace MVC_School.Controllers
{
    public class VakenController : Controller
    {
        private readonly SchoolDbContext _context;

        public VakenController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Vaken
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Vak.Include(v => v.Docent);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Vaken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .Include(v => v.Docent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vaken/Create
        public IActionResult Create()
        {
            ViewData["DocentId"] = new SelectList(_context.Docenten, "ID", "ID");
            return View();
        }

        // POST: Vaken/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naam,DocentId")] Vak vak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocentId"] = new SelectList(_context.Docenten, "ID", "ID", vak.DocentId);
            return View(vak);
        }

        // GET: Vaken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            ViewData["DocentId"] = new SelectList(_context.Docenten, "ID", "ID", vak.DocentId);
            return View(vak);
        }

        // POST: Vaken/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naam,DocentId")] Vak vak)
        {
            if (id != vak.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.ID))
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
            ViewData["DocentId"] = new SelectList(_context.Docenten, "ID", "ID", vak.DocentId);
            return View(vak);
        }

        // GET: Vaken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .Include(v => v.Docent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vaken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vak = await _context.Vak.FindAsync(id);
            _context.Vak.Remove(vak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(int id)
        {
            return _context.Vak.Any(e => e.ID == id);
        }
    }
}
