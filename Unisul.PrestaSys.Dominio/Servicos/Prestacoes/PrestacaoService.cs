using System.Collections.Generic;
using System.Linq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Helpers;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes
{
    public interface IPrestacaoService
    {
        int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao);
        int Create(Prestacao prestacao);
        int Delete(int id);
        bool Exists(int id);
        IQueryable<Prestacao> GetAll();
        IQueryable<Prestacao> GetAllByEmitenteId(int emitenteId);
        IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId, PrestacaoStatuses tipoAprovacao);
        IQueryable<PrestacaoTipo> GetAllPrestacaoTipos();
        Prestacao GetById(int id);
        int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao);
        int Update(Prestacao prestacao);
    }

    public class PrestacaoService : IPrestacaoService
    {
        private readonly IEmailHelper _emailHelper;
        private readonly IPrestacaoRepository _repository;
        private readonly IUsuarioService _usuarioService;

        public PrestacaoService(IPrestacaoRepository repository, IEmailHelper emailHelper,
            IUsuarioService usuarioService)
        {
            _repository = repository;
            _emailHelper = emailHelper;
            _usuarioService = usuarioService;
        }

        public int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao)
        {
            var prestacao = _repository.GetById(prestacaoId);

            switch (tipoAprovacao)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    prestacao.StatusId = (int) PrestacaoStatuses.EmAprovacaoFinanceira;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    prestacao.StatusId = (int) PrestacaoStatuses.Finalizada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatuses.Finalizada:
                    break;
                case PrestacaoStatuses.Rejeitada:
                    break;
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses) prestacao.StatusId);
            _emailHelper.EnviarEmail(prestacao, (PrestacaoStatuses) prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Create(Prestacao prestacao)
        {
            var emailTo = GetEmailTo(prestacao, PrestacaoStatuses.EmAprovacaoOperacional);
            _emailHelper.EnviarEmail(prestacao, PrestacaoStatuses.EmAprovacaoOperacional, emailTo);
            return _repository.Create(prestacao);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public IQueryable<Prestacao> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Prestacao> GetAllByEmitenteId(int emitenteId)
        {
            return _repository.GetAll().Where(pr => pr.EmitenteId == emitenteId);
        }

        public IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId, PrestacaoStatuses tipoAprovacao)
        {
            if (tipoAprovacao == PrestacaoStatuses.EmAprovacaoOperacional)
                return _repository.GetAll().Where(pr =>
                    pr.AprovadorId == aprovadorId &&
                    pr.StatusId == (int) PrestacaoStatuses.EmAprovacaoOperacional);

            if (tipoAprovacao == PrestacaoStatuses.EmAprovacaoFinanceira)
                return _repository.GetAll().Where(pr =>
                    pr.AprovadorFinanceiroId == aprovadorId &&
                    pr.StatusId == (int) PrestacaoStatuses.EmAprovacaoFinanceira);

            return new List<Prestacao>().AsQueryable();
        }

        public IQueryable<PrestacaoTipo> GetAllPrestacaoTipos()
        {
            return _repository.GetAllPrestacaoTipos();
        }

        public Prestacao GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao)
        {
            var prestacao = _repository.GetById(prestacaoId);

            switch (tipoAprovacao)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    prestacao.StatusId = (int) PrestacaoStatuses.Rejeitada;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    prestacao.StatusId = (int) PrestacaoStatuses.Rejeitada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatuses.Finalizada:
                    break;
                case PrestacaoStatuses.Rejeitada:
                    break;
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses) prestacao.StatusId);
            _emailHelper.EnviarEmail(prestacao, (PrestacaoStatuses) prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Update(Prestacao prestacao)
        {
            return _repository.Update(prestacao);
        }

        public string GetEmailTo(Prestacao prestacao, PrestacaoStatuses statusAtual)
        {
            switch (statusAtual)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorId);
                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId);
                case PrestacaoStatuses.Rejeitada:
                case PrestacaoStatuses.Finalizada:
                    return _usuarioService.GetUsuarioEmailById(prestacao.EmitenteId);
            }

            return string.Empty;
        }
    }
}
