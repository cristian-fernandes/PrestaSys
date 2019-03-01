using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Usuarios;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper) : base(usuarioService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            var usuarioViewModel = new UsuarioViewModel
            {
                GerenteSelectList = GetAllGerentesSelectList(),
                GerenteFinanceiroSelectList = GetAllGerentesFinanceirosSelectList()
            };

            return View(usuarioViewModel);
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Create(_mapper.Map<Usuario>(usuarioViewModel));
                return RedirectToAction(nameof(Index));
            }

            usuarioViewModel.GerenteSelectList = GetAllGerentesSelectList();
            usuarioViewModel.GerenteFinanceiroSelectList = GetAllGerentesFinanceirosSelectList();

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = _usuarioService.GetById(id.Value);

            if (usuario == null)
                return NotFound();

            return View(_mapper.Map<UsuarioViewModel>(usuario));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _usuarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = _usuarioService.GetById(id.Value);

            if (usuario == null)
                return NotFound();

            return View(_mapper.Map<UsuarioViewModel>(usuario));
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = _usuarioService.GetById(id.Value);

            if (usuario == null)
                return NotFound();

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            usuarioViewModel.GerenteSelectList = GetAllGerentesSelectList();
            usuarioViewModel.GerenteFinanceiroSelectList = GetAllGerentesFinanceirosSelectList();

            return View(usuarioViewModel);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioService.Update(_mapper.Map<Usuario>(usuarioViewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_usuarioService.Exists(usuarioViewModel.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            usuarioViewModel.GerenteSelectList = GetAllGerentesSelectList();
            usuarioViewModel.GerenteFinanceiroSelectList = GetAllGerentesFinanceirosSelectList();

            return View(usuarioViewModel);
        }

        // GET: Usuarios
        public IActionResult Index(int page = 1)
        {
            var todosUsuarios = _usuarioService.GetAll();

            var usuariosLista = todosUsuarios
                .OrderBy(u => u.Nome)
                .Skip((page - 1) * Constants.PageSize)
                .Take(Constants.PageSize);

            var usuariosListViewModel = new UsuarioListViewModel
            {
                PageNumber = page,
                TotalRecords = todosUsuarios.Count(),
                UsuariosList = _mapper.Map<List<Usuario>, List<UsuarioViewModel>>(usuariosLista.ToList())
            };

            return View(usuariosListViewModel);
        }

        private SelectList GetAllGerentesFinanceirosSelectList()
        {
            var gerentesFinanceiros = _usuarioService.GetAllGerentesFinanceiros().Select(x => new
            {
                x.Id,
                NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
            });

            return new SelectList(gerentesFinanceiros, "Id", "NomeCompleto");
        }

        private SelectList GetAllGerentesSelectList()
        {
            var gerentes = _usuarioService.GetAllGerentes().Select(x => new
            {
                x.Id,
                NomeCompleto = x.Nome + " " + x.Sobrenome.ToString()
            });

            return new SelectList(gerentes, "Id", "NomeCompleto");
        }
    }
}
