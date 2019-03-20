using System;
using System.Linq;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Helpers;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
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
        Prestacao GetById(int id);
        int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao);
        int Update(Prestacao prestacao);
        IQueryable<PrestacaoTipo> GetAllPrestacaoTipos();
    }

    public class PrestacaoService : IPrestacaoService
    {
        private readonly IPrestacaoRepository _repository;
        private readonly IEmailHelper _emailHelper;
        private readonly IUsuarioService _usuarioService;

        public PrestacaoService(IPrestacaoRepository repository, IEmailHelper emailHelper, IUsuarioService usuarioService)
        {
            _repository = repository;
            _emailHelper = emailHelper;
            _usuarioService = usuarioService;
        }

        public int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao)
        {
            Prestacao prestacao;

            switch (tipoAprovacao)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatuses.EmAprovacaoFinanceira;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatuses.Finalizada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatuses.Finalizada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                case PrestacaoStatuses.Rejeitada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoAprovacao), tipoAprovacao, null);
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses)prestacao.StatusId);
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

            throw new NotSupportedException();
        }

        public Prestacao GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao)
        {
            Prestacao prestacao;

            switch (tipoAprovacao)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatuses.Rejeitada;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatuses.Rejeitada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatuses.Finalizada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                case PrestacaoStatuses.Rejeitada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoAprovacao), tipoAprovacao, null);
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses)prestacao.StatusId);
            _emailHelper.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Update(Prestacao prestacao)
        {
            return _repository.Update(prestacao);
        }

        public IQueryable<PrestacaoTipo> GetAllPrestacaoTipos()
        {
            return _repository.GetAllPrestacaoTipos();
        }

        private string GetEmailTo(Prestacao prestacao, PrestacaoStatuses statusAtual)
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
