using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pagina_Web.Models.dbModels;
using Pagina_Web.Models.DTO;

namespace Pagina_Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly paginaVentasContext _context;

        public ProductoController(paginaVentasContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var paginaVentasContext = _context.Productos.Include(p => p.IdCatProdNavigation);
            return View(await paginaVentasContext.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCatProdNavigation)
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoCreateDTO producto)
        {
            if (ModelState.IsValid)
            {
            string? fileName = await GuardarFotografiaProductoAsync(producto.ImagenArchivo);
            Producto p = new Producto
            {
                IdCatProd = producto.IdCatProd,
                IdMarcProd = producto.IdMarcProd,
                Imagen = fileName,
                Sku = producto.Sku,
                CostoProd = producto.CostoProd,
                ExistenciaProd = producto.ExistenciaProd,
                DescuentoProd = producto.DescuentoProd,
                PrecioProd = producto.PrecioProd,
                DescripcionProd = producto.DescripcionProd
             };
             _context.Add(p);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
            }
            producto.Marcas = new SelectList(_context.MarcaProductos, "Id")
            return View(producto);
        }

        private Task<string?> GuardarFotografiaProductoAsync(object imagenArchivo)
        {
            throw new NotImplementedException();
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat", producto.IdCatProd);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProd,IdCatProd,Imagen,Sku,CostoProd,ExistenciaProd,DescuentoProd,PrecioProd,DescripcionProd")] ProductoCreateDTO producto)
        {
            if (id != producto.IdProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProd))
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
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat", producto.IdCatProd);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCatProdNavigation)
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'paginaVentasContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.IdProd == id)).GetValueOrDefault();
        }
    }
}
