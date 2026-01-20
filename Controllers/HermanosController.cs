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
    public class HermanosController : Controller
    {
        private readonly MyDbContext _context;

        public HermanosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Hermanos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Hermano.Include(h => h.Hermandad);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Hermanos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermano = await _context.Hermano
                .Include(h => h.Hermandad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hermano == null)
            {
                return NotFound();
            }

            return View(hermano);
        }

        // GET: Hermanos/Create
        public IActionResult Create()
        {
            ViewData["HermandadId"] = new SelectList(_context.Hermandad, "Id", "Nombre");
            return View();
        }

        // POST: Hermanos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,DNI,FechaNacimiento,Telefono,Email,HermandadId")] Hermano hermano)
        {

            _context.Add(hermano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Hermanos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermano = await _context.Hermano.FindAsync(id);
            if (hermano == null)
            {
                return NotFound();
            }
            ViewData["HermandadId"] = new SelectList(_context.Hermandad, "Id", "Nombre", hermano.HermandadId);
            return View(hermano);
        }

        // POST: Hermanos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,DNI,FechaNacimiento,Telefono,Email,HermandadId")] Hermano hermano)
        {
            if (id != hermano.Id)
            {
                return NotFound();
            }


            _context.Update(hermano);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }

        // GET: Hermanos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hermano = await _context.Hermano
                .Include(h => h.Hermandad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hermano == null)
            {
                return NotFound();
            }

            return View(hermano);
        }

        // POST: Hermanos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hermano = await _context.Hermano.FindAsync(id);
            if (hermano != null)
            {
                _context.Hermano.Remove(hermano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HermanoExists(int id)
        {
            return _context.Hermano.Any(e => e.Id == id);
        }
    }
}
