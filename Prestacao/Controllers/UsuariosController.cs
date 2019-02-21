using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prestacao.Models.Database;

namespace Prestacao.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly PrestacaoDbContext _context;

        public UsuariosController(PrestacaoDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var prestacaoDbContext = _context.Usuario.Include(u => u.Gerente).Include(u => u.GerenteFinanceiro);
            return View(await prestacaoDbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["GerenteId"] = new SelectList(_context.Usuario, "Id", "Email");
            ViewData["GerenteFinanceiroId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,Senha,FlagGerente,FlagGerenteFinanceiro,GerenteId,GerenteFinanceiroId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerenteId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteId);
            ViewData["GerenteFinanceiroId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteFinanceiroId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["GerenteId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteId);
            ViewData["GerenteFinanceiroId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteFinanceiroId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,Senha,FlagGerente,FlagGerenteFinanceiro,GerenteId,GerenteFinanceiroId")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["GerenteId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteId);
            ViewData["GerenteFinanceiroId"] = new SelectList(_context.Usuario, "Id", "Email", usuario.GerenteFinanceiroId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
