using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jsreport.Client;
using jsreport.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.PdfGeneration;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Web.Models.Prestacoes;
using Unisul.PrestaSys.Web.Services;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class PrestacoesController : BaseController
    {
        private readonly JsReportSettings _jsReportSettings;
        private readonly IMapper _mapper;
        private readonly IPrestacaoService _prestacaoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IViewRenderService _viewRenderService;


        public PrestacoesController(IUsuarioService usuarioService, IPrestacaoService prestacaoService, IMapper mapper,
            IOptions<JsReportSettings> jsReportSettings, IViewRenderService viewRenderService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
            _prestacaoService = prestacaoService;
            _mapper = mapper;
            _jsReportSettings = jsReportSettings.Value;
            _viewRenderService = viewRenderService;
        }

        public IActionResult Approve(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Approve/5
        [HttpPost]
        [ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveConfirmed(int id, string justificativaAprovacao)
        {
            _prestacaoService.AprovarPrestacao(id, justificativaAprovacao, PrestacaoStatusEnum.EmAprovacaoOperacional);
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        public IActionResult ApproveFinanceiro(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("ApproveFinanceiro")]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveFinanceiroConfirmed(int id, string justificativaAprovacaoFinanceira)
        {
            _prestacaoService.AprovarPrestacao(id, justificativaAprovacaoFinanceira,
                PrestacaoStatusEnum.EmAprovacaoFinanceira);
            return RedirectToAction(nameof(PrestacoesParaAprovarFinanceiro));
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
                var prestacao = _mapper.Map<Prestacao>(prestacaoViewModel);
                prestacao.ImagemComprovante = GetImageBytes(prestacaoViewModel.ImagemComprovante);
                _prestacaoService.Create(prestacao);
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

        // GET: Prestacoes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _prestacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Prestacoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

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

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            prestacaoViewModel.AprovadorId = usuarioLogado.GerenteId;
            prestacaoViewModel.AprovadorFinanceiroId = usuarioLogado.GerenteFinanceiroId;
            prestacaoViewModel.EmitenteId = usuarioLogado.Id;
            prestacaoViewModel.StatusId = prestacao.StatusId;
            prestacaoViewModel.TipoPrestacaoSelectList = GetAllPrestacoesSelectList(prestacaoViewModel.TipoId);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PrestacaoViewModel prestacaoViewModel)
        {
            var usuarioLogado = GetLoggedUser();

            if (id != prestacaoViewModel.Id)
                return NotFound();

            if (prestacaoViewModel.EmitenteId != usuarioLogado.Id)
                return Forbid();

            if (ModelState.IsValid)
            {
                try
                {
                    var prestacao = _mapper.Map<Prestacao>(prestacaoViewModel);
                    prestacao.ImagemComprovante = GetImageBytes(prestacaoViewModel.ImagemComprovante);
                    _prestacaoService.Update(prestacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_prestacaoService.Exists(prestacaoViewModel.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            };

            prestacaoViewModel.AprovadorId = usuarioLogado.GerenteId;
            prestacaoViewModel.AprovadorFinanceiroId = usuarioLogado.GerenteFinanceiroId;
            prestacaoViewModel.EmitenteId = usuarioLogado.Id;
            prestacaoViewModel.StatusId = (int) PrestacaoStatusEnum.EmAprovacaoOperacional;
            prestacaoViewModel.TipoPrestacaoSelectList = GetAllPrestacoesSelectList(prestacaoViewModel.TipoId);

            return View(prestacaoViewModel);
        }

        // GET: Prestacoes
        public IActionResult Index(int page = 1)
        {
            var todasPrestacoes = _prestacaoService.GetAllByEmitenteId(GetLoggedUser().Id);

            var prestacoesLista = todasPrestacoes.OrderByDescending(pr => pr.Data)
                .Skip((page - 1) * Constants.PageSize).Take(Constants.PageSize);

            var prestacoesListViewModel = new PrestacaoListViewModel
            {
                PageNumber = page,
                TotalRecords = todasPrestacoes.Count(),
                PrestacoesList = _mapper.Map<List<Prestacao>, List<PrestacaoViewModel>>(prestacoesLista.ToList())
            };

            return View(prestacoesListViewModel);
        }

        // GET: Prestacoes para Aprovar
        public IActionResult PrestacoesParaAprovar(int page = 1)
        {
            var todasPrestacoes =
                _prestacaoService.GetAllParaAprovacao(GetLoggedUser().Id, PrestacaoStatusEnum.EmAprovacaoOperacional);

            var prestacoesLista = todasPrestacoes.OrderByDescending(pr => pr.Data)
                .Skip((page - 1) * Constants.PageSize).Take(Constants.PageSize);

            var prestacoesListViewModel = new PrestacaoListViewModel
            {
                PageNumber = page,
                TotalRecords = todasPrestacoes.Count(),
                PrestacoesList = _mapper.Map<List<Prestacao>, List<PrestacaoViewModel>>(prestacoesLista.ToList())
            };

            return View(prestacoesListViewModel);
        }

        // GET: Prestacoes para Aprovar Financeiro
        public IActionResult PrestacoesParaAprovarFinanceiro(int page = 1)
        {
            var todasPrestacoes =
                _prestacaoService.GetAllParaAprovacao(GetLoggedUser().Id, PrestacaoStatusEnum.EmAprovacaoFinanceira);

            var prestacoesLista = todasPrestacoes.OrderByDescending(pr => pr.Data)
                .Skip((page - 1) * Constants.PageSize).Take(Constants.PageSize);

            var prestacoesListViewModel = new PrestacaoListViewModel
            {
                PageNumber = page,
                TotalRecords = todasPrestacoes.Count(),
                PrestacoesList = _mapper.Map<List<Prestacao>, List<PrestacaoViewModel>>(prestacoesLista.ToList())
            };

            return View(prestacoesListViewModel);
        }

        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            var jsReportingService = new ReportingService(_jsReportSettings.Uri,
                _jsReportSettings.UsernameEmail, _jsReportSettings.UsernamePassword);

            var htmlToRender = await _viewRenderService.RenderToStringAsync("~/Views/Prestacoes/Print.cshtml",
                prestacaoViewModel);

            var report = await jsReportingService.RenderAsync(new RenderRequest
            {
                Template = new Template
                {
                    Recipe = Recipe.ChromePdf,
                    Engine = Engine.Handlebars,
                    Content = htmlToRender
                }
            });

            return new FileStreamResult(report.Content, "application/pdf");
        }

        public IActionResult Reject(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Reject/5
        [HttpPost]
        [ActionName("Reject")]
        [ValidateAntiForgeryToken]
        public IActionResult RejectConfirmed(int id, string justificativaAprovacao)
        {
            _prestacaoService.RejeitarPrestacao(id, justificativaAprovacao, PrestacaoStatusEnum.EmAprovacaoOperacional);
            return RedirectToAction(nameof(PrestacoesParaAprovar));
        }

        public IActionResult RejectFinanceiro(int? id)
        {
            if (id == null)
                return NotFound();

            var prestacao = _prestacaoService.GetById(id.Value);

            if (prestacao == null)
                return NotFound();

            var prestacaoViewModel = _mapper.Map<PrestacaoViewModel>(prestacao);

            if (prestacao.ImagemComprovante != null)
                prestacaoViewModel.ImagemComprovanteSrc =
                    "data:image;base64," + Convert.ToBase64String(prestacao.ImagemComprovante);

            return View(prestacaoViewModel);
        }

        // POST: Prestacoes/Delete/5
        [HttpPost]
        [ActionName("RejectFinanceiro")]
        [ValidateAntiForgeryToken]
        public IActionResult RejectFinanceiroConfirmed(int id, string justificativaAprovacaoFinanceira)
        {
            _prestacaoService.RejeitarPrestacao(id, justificativaAprovacaoFinanceira,
                PrestacaoStatusEnum.EmAprovacaoFinanceira);
            return RedirectToAction(nameof(PrestacoesParaAprovarFinanceiro));
        }

        private SelectList GetAllPrestacoesSelectList()
        {
            return new SelectList(_prestacaoService.GetAllPrestacaoTipos(), "Id", "Tipo");
        }

        private SelectList GetAllPrestacoesSelectList(int tipoId)
        {
            return new SelectList(_prestacaoService.GetAllPrestacaoTipos(), "Id", "Tipo", tipoId);
        }

        private static byte[] GetImageBytes(IFormFile image)
        {
            if (image == null)
                return null;

            if (image.Length <= 0)
                return null;

            byte[] imageByte;

            using (var readStream = image.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                readStream.CopyTo(memoryStream);
                imageByte = memoryStream.ToArray();
            }

            return imageByte;
        }
    }
}
