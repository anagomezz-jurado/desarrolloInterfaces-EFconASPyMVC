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
    public class PuestoHermanosController : Controller
    {
        private readonly MyDbContext _context;

        public PuestoHermanosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PuestoHermanos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PuestoHermano.Include(p => p.Hermano).Include(p => p.Puesto);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PuestoHermanos/Details/5
        public async Task<IActionResult> Details(int? puestoId, int? hermanoId)
        {
            if (puestoId == null || hermanoId==null)
            {
                return NotFound();
            }

            var puestoHermano = await _context.PuestoHermano
                .Include(p => p.Hermano)
                .Include(p => p.Puesto)
                .FirstOrDefaultAsync(m => m.PuestoId == puestoId && m.HermanoId == hermanoId);
            if (puestoHermano == null)
            {
                return NotFound();
            }

            return View(puestoHermano);
        }

        // GET: PuestoHermanos/Create
        public IActionResult Create()
        {
            ViewData["HermanoId"] = new SelectList(_context.Hermano, "Id", "Nombre");
            ViewData["PuestoId"] = new SelectList(_context.Puesto, "Id", "NombrePuesto");
            return View();
        }

        // POST: PuestoHermanos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PuestoId,HermanoId,FechaInicio,FechaFin")] PuestoHermano puestoHermano)
        {
            _context.Add(puestoHermano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PuestoHermanos/Edit/5
        public async Task<IActionResult> Edit(int? puestoId, int? hermanoId)
        {
            if (puestoId == null || hermanoId == null)
            {
                return NotFound();
            }

            var puestoHermano = await _context.PuestoHermano.FindAsync(puestoId, hermanoId);
            if (puestoHermano == null)
            {
                return NotFound();
            }
            ViewData["HermanoId"] = new SelectList(_context.Hermano, "Id", "Nombre", puestoHermano.HermanoId);
            ViewData["PuestoId"] = new SelectList(_context.Puesto, "Id", "NombrePuesto", puestoHermano.PuestoId);
            return View(puestoHermano);
        }

        // POST: PuestoHermanos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? puestoId, int? hermanoId, [Bind("PuestoId,HermanoId,FechaInicio,FechaFin")] PuestoHermano puestoHermano)
        {
            if (puestoId == null || hermanoId == null)
            {
                return NotFound();
            }

            _context.Update(puestoHermano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: PuestoHermanos/Delete/5
        public async Task<IActionResult> Delete(int? puestoId, int? hermanoId)
        {
            if (puestoId == null || hermanoId == null)
            {
                return NotFound();
            }

            var puestoHermano = await _context.PuestoHermano
                .Include(p => p.Hermano)
                .Include(p => p.Puesto)
                .FirstOrDefaultAsync(m => m.PuestoId == puestoId && m.HermanoId == hermanoId);
            if (puestoHermano == null)
            {
                return NotFound();
            }

            return View(puestoHermano);
        }

        // POST: PuestoHermanos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? puestoId, int? hermanoId)
        {
            var puestoHermano = await _context.PuestoHermano.FindAsync(puestoId, hermanoId);
            if (puestoHermano != null)
            {
                _context.PuestoHermano.Remove(puestoHermano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoHermanoExists(int? puestoId, int? hermanoId)
        {
            return _context.PuestoHermano.Any(e => e.PuestoId == puestoId && e.HermanoId == hermanoId);

        }
    }
}
