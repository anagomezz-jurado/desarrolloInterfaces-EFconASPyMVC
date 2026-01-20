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
    public class TunicasController : Controller
    {
        private readonly MyDbContext _context;

        public TunicasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Tunicas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Tunica.Include(t => t.Hermano);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Tunicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tunica = await _context.Tunica
                .Include(t => t.Hermano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tunica == null)
            {
                return NotFound();
            }

            return View(tunica);
        }

        // GET: Tunicas/Create
        public IActionResult Create()
        {
            ViewData["HermanoId"] = new SelectList(_context.Hermano, "Id", "Nombre");
            return View();
        }

        // POST: Tunicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Color,Talla,Material,FechaEntrega,Estado,HermanoId")] Tunica tunica)
        {
           
                _context.Add(tunica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Tunicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tunica = await _context.Tunica.FindAsync(id);
            if (tunica == null)
            {
                return NotFound();
            }
            ViewData["HermanoId"] = new SelectList(_context.Hermano, "Id", "Nombre", tunica.HermanoId);
            return View(tunica);
        }

        // POST: Tunicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Color,Talla,Material,FechaEntrega,Estado,HermanoId")] Tunica tunica)
        {
            if (id != tunica.Id)
            {
                return NotFound();
            }

           
                    _context.Update(tunica);
                    await _context.SaveChangesAsync();
              
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Tunicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tunica = await _context.Tunica
                .Include(t => t.Hermano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tunica == null)
            {
                return NotFound();
            }

            return View(tunica);
        }

        // POST: Tunicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tunica = await _context.Tunica.FindAsync(id);
            if (tunica != null)
            {
                _context.Tunica.Remove(tunica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TunicaExists(int id)
        {
            return _context.Tunica.Any(e => e.Id == id);
        }
    }
}
