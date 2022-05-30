using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaProjeto2.Data;
using ProvaProjeto2.Models;

namespace ProvaProjeto2.Controllers
{
    public class FerramentasController : Controller
    {
        private readonly ProvaProjeto2Context _context;

        public FerramentasController(ProvaProjeto2Context context)
        {
            _context = context;
        }

        // GET: Ferramentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ferramenta.ToListAsync());
        }

        // GET: Ferramentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ferramenta = await _context.Ferramenta
                .FirstOrDefaultAsync(m => m.FerramentaId == id);
            if (ferramenta == null)
            {
                return NotFound();
            }

            return View(ferramenta);
        }

        // GET: Ferramentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ferramentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FerramentaId,NomeFerramenta,Disponivel")] Ferramenta ferramenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ferramenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ferramenta);
        }

        // GET: Ferramentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ferramenta = await _context.Ferramenta.FindAsync(id);
            if (ferramenta == null)
            {
                return NotFound();
            }
            return View(ferramenta);
        }

        // POST: Ferramentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FerramentaId,NomeFerramenta,Disponivel")] Ferramenta ferramenta)
        {
            if (id != ferramenta.FerramentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ferramenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FerramentaExists(ferramenta.FerramentaId))
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
            return View(ferramenta);
        }

        // GET: Ferramentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ferramenta = await _context.Ferramenta
                .FirstOrDefaultAsync(m => m.FerramentaId == id);
            if (ferramenta == null)
            {
                return NotFound();
            }

            return View(ferramenta);
        }

        // POST: Ferramentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ferramenta = await _context.Ferramenta.FindAsync(id);
            _context.Ferramenta.Remove(ferramenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FerramentaExists(int id)
        {
            return _context.Ferramenta.Any(e => e.FerramentaId == id);
        }
    }
}
