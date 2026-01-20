using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;

namespace EFconASPyMVC.Controllers
{
    public class HermandadesController : Controller
    {
        private readonly MyDbContext _context;

        public HermandadesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Hermandades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hermandad.ToListAsync());
        }

        // GET: Hermandades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermandad = await _context.Hermandad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hermandad == null)
            {
                return NotFound();
            }

            return View(hermandad);
        }

        // GET: Hermandades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hermandades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cif,FechaFundacion,Ciudad")] Hermandad hermandad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hermandad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hermandad);
        }

        // GET: Hermandades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermandad = await _context.Hermandad.FindAsync(id);
            if (hermandad == null)
            {
                return NotFound();
            }
            return View(hermandad);
        }

        // POST: Hermandades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cif,FechaFundacion,Ciudad")] Hermandad hermandad)
        {
            if (id != hermandad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hermandad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HermandadExists(hermandad.Id))
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
            return View(hermandad);
        }

        // GET: Hermandades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermandad = await _context.Hermandad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hermandad == null)
            {
                return NotFound();
            }

            return View(hermandad);
        }

        // POST: Hermandades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hermandad = await _context.Hermandad.FindAsync(id);
            if (hermandad != null)
            {
                _context.Hermandad.Remove(hermandad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HermandadExists(int id)
        {
            return _context.Hermandad.Any(e => e.Id == id);
        }
    }
}
