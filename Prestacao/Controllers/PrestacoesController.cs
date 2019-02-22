using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Repositorio.Models.Database;

namespace Prestacao.Controllers
{
    public class PrestacoesController : BaseController
    {
        private readonly PrestacaoDbContext _context;

        public PrestacoesController(PrestacaoDbContext context)
        {
            _context = context;
        }

        // GET: Prestacoes
        public async Task<IActionResult> Index()
        {
            var prestacaoDbContext = _context.Prestacao.Include(p => p.Aprovador).Include(p => p.AprovadorFinanceiro).Include(p => p.Emitente).Include(p => p.Status).Include(p => p.Tipo);
            return View(await prestacaoDbContext.ToListAsync());
        }

        // GET: Prestacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null)
            {
                return NotFound();
            }

            return View(prestacao);
        }

        // GET: Prestacoes/Create
        public IActionResult Create()
        {
            var usuarioLogado = GetLoggedUser();

            ViewData["AprovadorId"] = usuarioLogado.GerenteId;
            ViewData["AprovadorFinanceiroId"] = usuarioLogado.GerenteFinanceiroId;
            ViewData["EmitenteId"] = usuarioLogado.Id;
            ViewData["StatusId"] = _context.PrestacaoStatus.First(s => s.Status == "Iniciada").Id;
            ViewData["TipoId"] = new SelectList(_context.PrestacaoTipo, "Id", "Tipo");

            return View();
        }

        // POST: Prestacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AprovadorFinanceiroId,AprovadorId,Data,EmitenteId,ImagemComprovante,Justificativa,StatusId,TipoId,Titulo,Valor")] Repositorio.Models.Database.Prestacao prestacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestacao);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AprovadorId"] = new SelectList(_context.Usuario, "Id", "Email", prestacao.AprovadorId);
            ViewData["AprovadorFinanceiroId"] = new SelectList(_context.Usuario, "Id", "Email", prestacao.AprovadorFinanceiroId);
            ViewData["EmitenteId"] = new SelectList(_context.Usuario, "Id", "Email", prestacao.EmitenteId);
            ViewData["StatusId"] = new SelectList(_context.PrestacaoStatus, "Id", "Status", prestacao.StatusId);
            ViewData["TipoId"] = new SelectList(_context.PrestacaoTipo, "Id", "Tipo", prestacao.TipoId);
            return View(prestacao);
        }

        // GET: Prestacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestacao = await _context.Prestacao.FindAsync(id);

            if (prestacao == null)
            {
                return NotFound();
            }

            var usuarioLogado = GetLoggedUser();

            ViewData["AprovadorId"] = usuarioLogado.GerenteId;
            ViewData["AprovadorFinanceiroId"] = usuarioLogado.GerenteFinanceiroId;
            ViewData["EmitenteId"] = usuarioLogado.Id;
            ViewData["StatusId"] = _context.PrestacaoStatus.First(s => s.Status == "Iniciada").Id;
            ViewData["TipoId"] = new SelectList(_context.PrestacaoTipo, "Id", "Tipo");

            return View(prestacao);
        }

        // POST: Prestacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AprovadorFinanceiroId,AprovadorId,Data,EmitenteId,Id,ImagemComprovante,Justificativa,StatusId,TipoId,Titulo,Valor")] Repositorio.Models.Database.Prestacao prestacao)
        {
            if (id != prestacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestacao);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestacaoExists(prestacao.Id))
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

            var usuarioLogado = GetLoggedUser();

            ViewData["AprovadorId"] = usuarioLogado.GerenteId;
            ViewData["AprovadorFinanceiroId"] = usuarioLogado.GerenteFinanceiroId;
            ViewData["EmitenteId"] = usuarioLogado.Id;
            ViewData["StatusId"] = _context.PrestacaoStatus.First(s => s.Status == "Iniciada").Id;
            ViewData["TipoId"] = new SelectList(_context.PrestacaoTipo, "Id", "Tipo");

            return View(prestacao);
        }

        // GET: Prestacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null)
            {
                return NotFound();
            }

            return View(prestacao);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            _context.Prestacao.Remove(prestacao);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestacaoExists(int id)
        {
            return _context.Prestacao.Any(e => e.Id == id);
        }

        private Usuario GetLoggedUser()
        {
            var listaUsuarios = _context.Usuario.Where(u => u.Email == GetClaimValuebyType(ClaimTypes.Email)).ToList();

            if (listaUsuarios.Count > 0)
            {
                var usuarioLogado = listaUsuarios.First();

                return usuarioLogado;
            }

            RedirectToAction("Index", "Home");
            return null;
        }

        private string GetClaimValuebyType(string type)
        {
            return Request.HttpContext.User.Claims.First(t => t.Type == type).Value;
        }
    }
}
