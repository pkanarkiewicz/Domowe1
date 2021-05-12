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
    public class FormattsController : Controller
    {
        private readonly MvcFormattContext _context;

        public FormattsController(MvcFormattContext context)
        {
            _context = context;
        }

        // GET: Formatts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Formatt.ToListAsync());
        }

        // GET: Formatts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatt = await _context.Formatt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatt == null)
            {
                return NotFound();
            }

            return View(formatt);
        }

        // GET: Formatts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formatts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Price")] Formatt formatt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formatt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formatt);
        }

        // GET: Formatts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatt = await _context.Formatt.FindAsync(id);
            if (formatt == null)
            {
                return NotFound();
            }
            return View(formatt);
        }

        // POST: Formatts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price")] Formatt formatt)
        {
            if (id != formatt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formatt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormattExists(formatt.Id))
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
            return View(formatt);
        }

        // GET: Formatts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatt = await _context.Formatt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatt == null)
            {
                return NotFound();
            }

            return View(formatt);
        }

        // POST: Formatts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formatt = await _context.Formatt.FindAsync(id);
            _context.Formatt.Remove(formatt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormattExists(int id)
        {
            return _context.Formatt.Any(e => e.Id == id);
        }
    }
}
