using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Repositorio;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Web.Models.Prestacoes;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class PrestacoesController : BaseController
    {
        private readonly IPrestaSysDbContext _context;
        private readonly IUsuarioService _usuarioService;
        private readonly IPrestacaoService _prestacaoService;
        private readonly IMapper _mapper;

        public PrestacoesController(IPrestaSysDbContext context, IUsuarioService usuarioService, IPrestacaoService prestacaoService, IMapper mapper) : base(usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
            _prestacaoService = prestacaoService;
            _mapper = mapper;
        }

        // GET: Prestacoes
        public IActionResult Index(int page = 1)
        {
            var todasPrestacoes = _prestacaoService.GetAllByEmitenteId(GetLoggedUser().Id);

            var prestacoesLista = todasPrestacoes.OrderByDescending(pr => pr.Data)
                .Skip((page - 1) * Constants.PAGE_SIZE).Take(Constants.PAGE_SIZE);

            var prestacoesListViewModel = new PrestacaoListViewModel
            {
                PageNumber = page,
                TotalRecords = todasPrestacoes.Count(),
                PrestacoesList = _mapper.Map<List<Prestacao>, List<PrestacaoViewModel>>(prestacoesLista.ToList())
            };

            return View(prestacoesListViewModel);
        }

        // GET: Prestacoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            //TODO Pegar somente as prestações que tem a ver com o usuário
            var usuarioLogado = GetLoggedUser();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            return View(_mapper.Map<PrestacaoViewModel>(prestacao));
        }

        // GET: Prestacoes/Create
        public IActionResult Create()
        {
            var usuarioLogado = GetLoggedUser();

            var prestacaoViewModel = new PrestacaoViewModel
            {
                AprovadorId = usuarioLogado.GerenteId,
                AprovadorFinanceiroId = usuarioLogado.GerenteFinanceiroId,
                EmitenteId = usuarioLogado.Id,
                StatusId = (int) PrestacaoStatusEnum.EmAprovacaoOperacional,
                TipoPrestacaoSelectList = GetAllPrestacoesSelectList()
            };

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PrestacaoViewModel prestacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _prestacaoService.Create(_mapper.Map<Prestacao>(prestacaoViewModel));
                return RedirectToAction(nameof(Index));
            }

            var usuarioLogado = GetLoggedUser();

            prestacaoViewModel.AprovadorId = usuarioLogado.GerenteId;
            prestacaoViewModel.AprovadorFinanceiroId = usuarioLogado.GerenteFinanceiroId;
            prestacaoViewModel.EmitenteId = usuarioLogado.Id;
            prestacaoViewModel.StatusId = (int) PrestacaoStatusEnum.EmAprovacaoOperacional;
            prestacaoViewModel.TipoPrestacaoSelectList = GetAllPrestacoesSelectList(prestacaoViewModel.TipoId);

            return View(prestacaoViewModel);
        }

        // GET: Prestacoes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var usuarioLogado = GetLoggedUser();

            if (prestacao.EmitenteId != usuarioLogado.Id)
                return Forbid();

            var prestacaoViewModel = new PrestacaoViewModel
            {
                AprovadorId = usuarioLogado.GerenteId,
                AprovadorFinanceiroId = usuarioLogado.GerenteFinanceiroId,
                EmitenteId = usuarioLogado.Id,
                StatusId = (int)PrestacaoStatusEnum.EmAprovacaoOperacional,
                TipoPrestacaoSelectList = GetAllPrestacoesSelectList(prestacao.TipoId)
            };

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "AprovadorFinanceiroId,AprovadorId,Data,EmitenteId,Id,ImagemComprovante,Justificativa,StatusId,TipoId,Titulo,Valor")]
            Entidades.Prestacoes.Prestacao prestacao)
        {
            if (id != prestacao.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestacaoExists(prestacao.Id))
                        return NotFound();
                    throw;
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
            if (id == null) return NotFound();

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null) return NotFound();

            return View(prestacao);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            _context.Prestacao.Remove(prestacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestacaoExists(int id)
        {
            return _context.Prestacao.Any(e => e.Id == id);
        }

        // GET: Prestacoes para Aprovar
        public async Task<IActionResult> PrestacoesParaAprovar(int p = 1, int s = 8)
        {
            var prestacaoDbContext = _context.Prestacao.Where(pr =>
                    pr.AprovadorId == GetLoggedUser().Id &&
                    pr.StatusId == (int)PrestacaoStatusEnum.EmAprovacaoOperacional)
                .Include(pr => pr.Aprovador).Include(pr => pr.AprovadorFinanceiro).Include(pr => pr.Emitente)
                .Include(pr => pr.Status).Include(pr => pr.Tipo)
                .OrderByDescending(pr => pr.Data).Skip((p - 1) * s).Take(s);

            ViewBag.TotalRecords = _context.Prestacao.Count(pr => pr.AprovadorId == GetLoggedUser().Id &&
                                                                  pr.StatusId == (int)PrestacaoStatusEnum.EmAprovacaoOperacional);
            ViewBag.PageNumber = p;

            return View(await prestacaoDbContext.ToListAsync());
        }

        public async Task<IActionResult> Reject(int? id)
        {
            if (id == null) return NotFound();

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null) return NotFound();

            return View(prestacao);
        }

        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null) return NotFound();

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null) return NotFound();

            return View(prestacao);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("Reject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectConfirmed(int id, string justificativaAprovacao)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            prestacao.StatusId = (int)PrestacaoStatusEnum.Rejeitada;
            prestacao.JustificativaAprovacao = justificativaAprovacao;
            _context.Update(prestacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmed(int id, string justificativaAprovacao)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            prestacao.StatusId = (int)PrestacaoStatusEnum.EmAprovacaoFinanceira;
            prestacao.JustificativaAprovacao = justificativaAprovacao;
            _context.Update(prestacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        // GET: Prestacoes para Aprovar Financeiro
        public async Task<IActionResult> PrestacoesParaAprovarFinanceiro(int p = 1, int s = 8)
        {
            var prestacaoDbContext = _context.Prestacao.Where(pr =>
                    pr.AprovadorFinanceiroId == GetLoggedUser().Id &&
                    pr.StatusId == (int)PrestacaoStatusEnum.EmAprovacaoFinanceira)
                .Include(pr => pr.Aprovador).Include(pr => pr.AprovadorFinanceiro).Include(pr => pr.Emitente)
                .Include(pr => pr.Status).Include(pr => pr.Tipo)
                .OrderByDescending(pr => pr.Data).Skip((p - 1) * s).Take(s);

            ViewBag.TotalRecords = _context.Prestacao.Count(pr => pr.AprovadorFinanceiroId == GetLoggedUser().Id &&
                                                                  pr.StatusId == (int)PrestacaoStatusEnum.EmAprovacaoFinanceira);
            ViewBag.PageNumber = p;

            return View(await prestacaoDbContext.ToListAsync());
        }

        public async Task<IActionResult> RejectFinanceiro(int? id)
        {
            if (id == null) return NotFound();

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null) return NotFound();

            return View(prestacao);
        }

        public async Task<IActionResult> ApproveFinanceiro(int? id)
        {
            if (id == null) return NotFound();

            var prestacao = await _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestacao == null) return NotFound();

            return View(prestacao);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("RejectFinanceiro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectFinanceiroConfirmed(int id, string justificativaAprovacaoFinanceira)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            prestacao.StatusId = (int)PrestacaoStatusEnum.Rejeitada;
            prestacao.JustificativaAprovacaoFinanceira = justificativaAprovacaoFinanceira;
            _context.Update(prestacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("ApproveFinanceiro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveFinanceirpConfirmed(int id, string justificativaAprovacaoFinanceira)
        {
            var prestacao = await _context.Prestacao.FindAsync(id);
            prestacao.StatusId = (int)PrestacaoStatusEnum.Finalizada;
            prestacao.JustificativaAprovacaoFinanceira = justificativaAprovacaoFinanceira;
            _context.Update(prestacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        private SelectList GetAllPrestacoesSelectList()
        {
            return new SelectList(_prestacaoService.GetAllPrestacaoTipos(), "Id", "Tipo");
        }

        private SelectList GetAllPrestacoesSelectList(int tipoId)
        {
            return new SelectList(_prestacaoService.GetAllPrestacaoTipos(), "Id", "Tipo", tipoId);
        }
    }
}
