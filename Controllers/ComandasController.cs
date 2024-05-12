using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Magazin_Online.Data;
using Magazin_Online.Models;

namespace Magazin_Online.Controllers
{
    public class ComandasController : Controller
    {
        private readonly AppDbContext _context;

        public ComandasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Comandas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Comanda.Include(c => c.Admin).Include(c => c.Utilizator);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .Include(c => c.Admin)
                .Include(c => c.Utilizator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Password");
            ViewData["UtilizatorId"] = new SelectList(_context.Utilizator, "Id", "Adresa");
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NrComanda,NrBuc,DataComanda,StareComanda,AdminId,UtilizatorId")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Password", comanda.AdminId);
            ViewData["UtilizatorId"] = new SelectList(_context.Utilizator, "Id", "Adresa", comanda.UtilizatorId);
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Password", comanda.AdminId);
            ViewData["UtilizatorId"] = new SelectList(_context.Utilizator, "Id", "Adresa", comanda.UtilizatorId);
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NrComanda,NrBuc,DataComanda,StareComanda,AdminId,UtilizatorId")] Comanda comanda)
        {
            if (id != comanda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Password", comanda.AdminId);
            ViewData["UtilizatorId"] = new SelectList(_context.Utilizator, "Id", "Adresa", comanda.UtilizatorId);
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .Include(c => c.Admin)
                .Include(c => c.Utilizator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comanda = await _context.Comanda.FindAsync(id);
            if (comanda != null)
            {
                _context.Comanda.Remove(comanda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
            return _context.Comanda.Any(e => e.Id == id);
        }
    }
}
