using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamilySolorzano.Models;

namespace CamilySolorzano.Controllers
{
    public class PlanDeRecompensasController : Controller
    {
        private readonly CamilySolorzanoP1 _context;

        public PlanDeRecompensasController(CamilySolorzanoP1 context)
        {
            _context = context;
        }

        // GET: PlanDeRecompensas
        public async Task<IActionResult> Index()
        {
            var camilySolorzanoP1 = _context.PlanDeRecompensa.Include(p => p.Cliente).Include(p => p.Reserva);
            return View(await camilySolorzanoP1.ToListAsync());
        }

        // GET: PlanDeRecompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensa = await _context.PlanDeRecompensa
                .Include(p => p.Cliente)
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.idPlanRecompensa == id);
            if (planDeRecompensa == null)
            {
                return NotFound();
            }

            return View(planDeRecompensa);
        }

        // GET: PlanDeRecompensas/Create
        public IActionResult Create()
        {
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "NombreCliente");
            ViewData["idReserva"] = new SelectList(_context.Reserva, "idReserva", "idReserva");
            return View();
        }

        // POST: PlanDeRecompensas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPlanRecompensa,nombre,FechaInicio,puntosAcumulados,recompensa,idCliente,idReserva")] PlanDeRecompensa planDeRecompensa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planDeRecompensa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "NombreCliente", planDeRecompensa.idCliente);
            ViewData["idReserva"] = new SelectList(_context.Reserva, "idReserva", "idReserva", planDeRecompensa.idReserva);
            return View(planDeRecompensa);
        }

        // GET: PlanDeRecompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensa = await _context.PlanDeRecompensa.FindAsync(id);
            if (planDeRecompensa == null)
            {
                return NotFound();
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "NombreCliente", planDeRecompensa.idCliente);
            ViewData["idReserva"] = new SelectList(_context.Reserva, "idReserva", "idReserva", planDeRecompensa.idReserva);
            return View(planDeRecompensa);
        }

        // POST: PlanDeRecompensas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPlanRecompensa,nombre,FechaInicio,puntosAcumulados,recompensa,idCliente,idReserva")] PlanDeRecompensa planDeRecompensa)
        {
            if (id != planDeRecompensa.idPlanRecompensa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planDeRecompensa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanDeRecompensaExists(planDeRecompensa.idPlanRecompensa))
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
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "NombreCliente", planDeRecompensa.idCliente);
            ViewData["idReserva"] = new SelectList(_context.Reserva, "idReserva", "idReserva", planDeRecompensa.idReserva);
            return View(planDeRecompensa);
        }

        // GET: PlanDeRecompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensa = await _context.PlanDeRecompensa
                .Include(p => p.Cliente)
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.idPlanRecompensa == id);
            if (planDeRecompensa == null)
            {
                return NotFound();
            }

            return View(planDeRecompensa);
        }

        // POST: PlanDeRecompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planDeRecompensa = await _context.PlanDeRecompensa.FindAsync(id);
            if (planDeRecompensa != null)
            {
                _context.PlanDeRecompensa.Remove(planDeRecompensa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanDeRecompensaExists(int id)
        {
            return _context.PlanDeRecompensa.Any(e => e.idPlanRecompensa == id);
        }
    }
}
