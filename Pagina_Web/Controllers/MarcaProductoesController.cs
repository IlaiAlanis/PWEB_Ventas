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
    public class MarcaProductoesController : Controller
    {
        private readonly paginaVentasContextDTO _context;

        public MarcaProductoesController(paginaVentasContextDTO context)
        {
            _context = context;
        }

        // GET: MarcaProductoes
        public async Task<IActionResult> Index()
        {
              return _context.MarcaProductos != null ? 
                          View(await _context.MarcaProductos.ToListAsync()) :
                          Problem("Entity set 'paginaVentasContext.MarcaProductos'  is null.");
        }

        // GET: MarcaProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // GET: MarcaProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,NombreMar,DescripcionMar")] MarcaProductoDTO marcaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaProducto);
        }

        // GET: MarcaProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos.FindAsync(id);
            if (marcaProducto == null)
            {
                return NotFound();
            }
            return View(marcaProducto);
        }

        // POST: MarcaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,NombreMar,DescripcionMar")] MarcaProductoDTO marcaProducto)
        {
            if (id != marcaProducto.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaProductoExists(marcaProducto.IdMarca))
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
            return View(marcaProducto);
        }

        // GET: MarcaProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // POST: MarcaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaProductos == null)
            {
                return Problem("Entity set 'paginaVentasContext.MarcaProductos'  is null.");
            }
            var marcaProducto = await _context.MarcaProductos.FindAsync(id);
            if (marcaProducto != null)
            {
                _context.MarcaProductos.Remove(marcaProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaProductoExists(int id)
        {
          return (_context.MarcaProductos?.Any(e => e.IdMarca == id)).GetValueOrDefault();
        }
    }
}
