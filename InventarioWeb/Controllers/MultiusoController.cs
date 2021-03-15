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
    public class MultiusoController : Controller
    {
        private readonly DataContext _context;

        public MultiusoController(DataContext context)
        {
            _context = context;
        }

        // GET: Multiuso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Multiusos.ToListAsync());
        }

        // GET: Multiuso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiuso = await _context.Multiusos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiuso == null)
            {
                return NotFound();
            }

            return View(multiuso);
        }

        // GET: Multiuso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Multiuso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Valor,Idpadre,Orden,Tipodato,Estado")] Multiuso multiuso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multiuso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multiuso);
        }

        // GET: Multiuso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiuso = await _context.Multiusos.FindAsync(id);
            if (multiuso == null)
            {
                return NotFound();
            }
            return View(multiuso);
        }

        // POST: Multiuso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Valor,Idpadre,Orden,Tipodato,Estado")] Multiuso multiuso)
        {
            if (id != multiuso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multiuso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiusoExists(multiuso.Id))
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
            return View(multiuso);
        }

        // GET: Multiuso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiuso = await _context.Multiusos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiuso == null)
            {
                return NotFound();
            }

            return View(multiuso);
        }

        // POST: Multiuso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multiuso = await _context.Multiusos.FindAsync(id);
            _context.Multiusos.Remove(multiuso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiusoExists(int id)
        {
            return _context.Multiusos.Any(e => e.Id == id);
        }
    }
}
