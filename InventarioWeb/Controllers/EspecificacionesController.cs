using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioWeb.Models;

namespace InventarioWeb.Controllers
{
    public class EspecificacionesController : Controller
    {
        private readonly DataContext _context;

        public EspecificacionesController(DataContext context)
        {
            _context = context;
        }

        // GET: Especificaciones
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Especificacionesproductos.Include(e => e.IdproductoNavigation);
            return View(await dataContext.ToListAsync());
        }

        // GET: Especificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacionesproducto = await _context.Especificacionesproductos
                .Include(e => e.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especificacionesproducto == null)
            {
                return NotFound();
            }

            return View(especificacionesproducto);
        }

        // GET: Especificaciones/Create
        public IActionResult Create()
        {
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        // POST: Especificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idproducto,Nombre,Valor")] Especificacionesproducto especificacionesproducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especificacionesproducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Id", "Id", especificacionesproducto.Idproducto);
            return View(especificacionesproducto);
        }

        // GET: Especificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacionesproducto = await _context.Especificacionesproductos.FindAsync(id);
            if (especificacionesproducto == null)
            {
                return NotFound();
            }
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Id", "Id", especificacionesproducto.Idproducto);
            return View(especificacionesproducto);
        }

        // POST: Especificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idproducto,Nombre,Valor")] Especificacionesproducto especificacionesproducto)
        {
            if (id != especificacionesproducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especificacionesproducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecificacionesproductoExists(especificacionesproducto.Id))
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
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Id", "Id", especificacionesproducto.Idproducto);
            return View(especificacionesproducto);
        }

        // GET: Especificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacionesproducto = await _context.Especificacionesproductos
                .Include(e => e.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especificacionesproducto == null)
            {
                return NotFound();
            }

            return View(especificacionesproducto);
        }

        // POST: Especificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especificacionesproducto = await _context.Especificacionesproductos.FindAsync(id);
            _context.Especificacionesproductos.Remove(especificacionesproducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecificacionesproductoExists(int id)
        {
            return _context.Especificacionesproductos.Any(e => e.Id == id);
        }
    }
}
