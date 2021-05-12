using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domowe1.Data;
using Domowe1.Models;

namespace Domowe1.Controllers
{
    public class DrawsController : Controller
    {
        private readonly MvcDrawContext _context;

        public DrawsController(MvcDrawContext context)
        {
            _context = context;
        }

        // GET: Draws
        public async Task<IActionResult> Index()
        {
            return View(await _context.Draw.ToListAsync());
        }

        // GET: Draws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (draw == null)
            {
                return NotFound();
            }

            return View(draw);
        }

        // GET: Draws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Draws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Price")] Draw draw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(draw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(draw);
        }

        // GET: Draws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draw.FindAsync(id);
            if (draw == null)
            {
                return NotFound();
            }
            return View(draw);
        }

        // POST: Draws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price")] Draw draw)
        {
            if (id != draw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(draw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawExists(draw.Id))
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
            return View(draw);
        }

        // GET: Draws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (draw == null)
            {
                return NotFound();
            }

            return View(draw);
        }

        // POST: Draws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var draw = await _context.Draw.FindAsync(id);
            _context.Draw.Remove(draw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawExists(int id)
        {
            return _context.Draw.Any(e => e.Id == id);
        }
    }
}
