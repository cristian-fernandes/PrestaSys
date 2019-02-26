using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Repositorio;
using Repositorio.Models.Database;

namespace Prestacao.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly PrestacaoDbContext _context;

        public UsuariosController(PrestacaoDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            var gerentes = _context.Usuario
                .Where(x => x.FlagGerente)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            var gerentesFinanceiros = _context.Usuario
                .Where(x => x.FlagGerenteFinanceiro)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });


            ViewData["GerenteId"] = new SelectList(gerentes, "Id", "NomeCompleto");
            ViewData["GerenteFinanceiroId"] = new SelectList(gerentesFinanceiros, "Id", "NomeCompleto");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Nome,Sobrenome,Email,Senha,FlagGerente,FlagGerenteFinanceiro,GerenteId,GerenteFinanceiroId")]
            Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var gerentes = _context.Usuario
                .Where(x => x.FlagGerente)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            var gerentesFinanceiros = _context.Usuario
                .Where(x => x.FlagGerenteFinanceiro)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            ViewData["GerenteId"] = new SelectList(gerentes, "Id", "NomeCompleto");
            ViewData["GerenteFinanceiroId"] = new SelectList(gerentesFinanceiros, "Id", "NomeCompleto");

            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return NotFound();

            var gerentes = _context.Usuario
                .Where(x => x.FlagGerente)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            var gerentesFinanceiros = _context.Usuario
                .Where(x => x.FlagGerenteFinanceiro)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            ViewData["GerenteId"] = new SelectList(gerentes, "Id", "NomeCompleto");
            ViewData["GerenteFinanceiroId"] = new SelectList(gerentesFinanceiros, "Id", "NomeCompleto");
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Nome,Sobrenome,Email,Senha,FlagGerente,FlagGerenteFinanceiro,GerenteId,GerenteFinanceiroId")]
            Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

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
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            var gerentes = _context.Usuario
                .Where(x => x.FlagGerente)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            var gerentesFinanceiros = _context.Usuario
                .Where(x => x.FlagGerenteFinanceiro)
                .Select(x => new
                {
                    x.Id,
                    NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
                });

            ViewData["GerenteId"] = new SelectList(gerentes, "Id", "NomeCompleto");
            ViewData["GerenteFinanceiroId"] = new SelectList(gerentesFinanceiros, "Id", "NomeCompleto");

            return View(usuario);
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(int p = 1, int s = 8)
        {
            var usuarios = _context.Usuario.Include(u => u.Gerente).Include(u => u.GerenteFinanceiro)
                .OrderBy(u => u.Nome).Skip((p - 1) * s).Take(s);

            ViewBag.TotalRecords = _context.Usuario.Count();
            ViewBag.PageNumber = p;

            return View(await usuarios.ToListAsync());
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
