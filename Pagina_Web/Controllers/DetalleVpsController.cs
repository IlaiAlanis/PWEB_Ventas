using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pagina_Web.Models.dbModels;

namespace Pagina_Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DetalleVpsController : Controller
    {
        private readonly paginaVentasContext _context;

        public DetalleVpsController(paginaVentasContext context)
        {
            _context = context;
        }

        // GET: DetalleVps
        public async Task<IActionResult> Index()
        {
            var paginaVentasContext = _context.DetalleVps.Include(d => d.IdProductoDvpNavigation).Include(d => d.IdVentaDvpNavigation);
            return View(await paginaVentasContext.ToListAsync());
        }

        // GET: DetalleVps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleVps == null)
            {
                return NotFound();
            }

            var detalleVp = await _context.DetalleVps
                .Include(d => d.IdProductoDvpNavigation)
                .Include(d => d.IdVentaDvpNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaDvp == id);
            if (detalleVp == null)
            {
                return NotFound();
            }

            return View(detalleVp);
        }

        // GET: DetalleVps/Create
        public IActionResult Create()
        {
            ViewData["IdProductoDvp"] = new SelectList(_context.Productos, "IdProd", "IdProd");
            ViewData["IdVentaDvp"] = new SelectList(_context.Venta, "IdVenta", "IdVenta");
            return View();
        }

        // POST: DetalleVps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaDvp,IdProductoDvp,PrecioDvp,CantidadDvp")] DetalleVp detalleVp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProductoDvp"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleVp.IdProductoDvp);
            ViewData["IdVentaDvp"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", detalleVp.IdVentaDvp);
            return View(detalleVp);
        }

        // GET: DetalleVps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleVps == null)
            {
                return NotFound();
            }

            var detalleVp = await _context.DetalleVps.FindAsync(id);
            if (detalleVp == null)
            {
                return NotFound();
            }
            ViewData["IdProductoDvp"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleVp.IdProductoDvp);
            ViewData["IdVentaDvp"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", detalleVp.IdVentaDvp);
            return View(detalleVp);
        }

        // POST: DetalleVps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaDvp,IdProductoDvp,PrecioDvp,CantidadDvp")] DetalleVp detalleVp)
        {
            if (id != detalleVp.IdVentaDvp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVpExists(detalleVp.IdVentaDvp))
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
            ViewData["IdProductoDvp"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleVp.IdProductoDvp);
            ViewData["IdVentaDvp"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", detalleVp.IdVentaDvp);
            return View(detalleVp);
        }

        // GET: DetalleVps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleVps == null)
            {
                return NotFound();
            }

            var detalleVp = await _context.DetalleVps
                .Include(d => d.IdProductoDvpNavigation)
                .Include(d => d.IdVentaDvpNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaDvp == id);
            if (detalleVp == null)
            {
                return NotFound();
            }

            return View(detalleVp);
        }

        // POST: DetalleVps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleVps == null)
            {
                return Problem("Entity set 'paginaVentasContext.DetalleVps'  is null.");
            }
            var detalleVp = await _context.DetalleVps.FindAsync(id);
            if (detalleVp != null)
            {
                _context.DetalleVps.Remove(detalleVp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVpExists(int id)
        {
          return (_context.DetalleVps?.Any(e => e.IdVentaDvp == id)).GetValueOrDefault();
        }
    }
}
