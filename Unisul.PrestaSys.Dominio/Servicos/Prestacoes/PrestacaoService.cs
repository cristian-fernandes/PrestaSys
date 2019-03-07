using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Helpers;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes
{
    public interface IPrestacaoService
    {
        int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatusEnum tipoAprovacao);
        int Create(Prestacao prestacao);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Prestacao, PrestacaoTipo> GetAll();
        IQueryable<Prestacao> GetAllByEmitenteId(int emitenteId);
        IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId, PrestacaoStatusEnum tipoAprovacao);
        Prestacao GetById(int id);
        int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatusEnum tipoAprovacao);
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

        public int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatusEnum tipoAprovacao)
        {
            Prestacao prestacao;

            switch (tipoAprovacao)
            {
                case PrestacaoStatusEnum.EmAprovacaoOperacional:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatusEnum.EmAprovacaoFinanceira;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatusEnum.EmAprovacaoFinanceira:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatusEnum.Finalizada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatusEnum.Finalizada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                case PrestacaoStatusEnum.Rejeitada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoAprovacao), tipoAprovacao, null);
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatusEnum)prestacao.StatusId);
            _emailHelper.EnviarEmail(prestacao, (PrestacaoStatusEnum) prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Create(Prestacao prestacao)
        {
            var emailTo = GetEmailTo(prestacao, PrestacaoStatusEnum.EmAprovacaoOperacional);
            _emailHelper.EnviarEmail(prestacao, PrestacaoStatusEnum.EmAprovacaoOperacional, emailTo);
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

        public IIncludableQueryable<Prestacao, PrestacaoTipo> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Prestacao> GetAllByEmitenteId(int emitenteId)
        {
            return _repository.GetAll().Where(pr => pr.EmitenteId == emitenteId);
        }

        public IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId, PrestacaoStatusEnum tipoAprovacao)
        {
            if (tipoAprovacao == PrestacaoStatusEnum.EmAprovacaoOperacional)
                return _repository.GetAll().Where(pr =>
                    pr.AprovadorId == aprovadorId &&
                    pr.StatusId == (int) PrestacaoStatusEnum.EmAprovacaoOperacional);

            if (tipoAprovacao == PrestacaoStatusEnum.EmAprovacaoFinanceira)
                return _repository.GetAll().Where(pr =>
                    pr.AprovadorFinanceiroId == aprovadorId &&
                    pr.StatusId == (int) PrestacaoStatusEnum.EmAprovacaoFinanceira);

            throw new NotSupportedException();
        }

        public Prestacao GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int RejeitarPrestacao(int prestacaoId, string justificativa, PrestacaoStatusEnum tipoAprovacao)
        {
            Prestacao prestacao;

            switch (tipoAprovacao)
            {
                case PrestacaoStatusEnum.EmAprovacaoOperacional:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatusEnum.Rejeitada;
                    prestacao.JustificativaAprovacao = justificativa;
                    break;

                case PrestacaoStatusEnum.EmAprovacaoFinanceira:
                    prestacao = _repository.GetById(prestacaoId);
                    prestacao.StatusId = (int) PrestacaoStatusEnum.Rejeitada;
                    prestacao.JustificativaAprovacaoFinanceira = justificativa;
                    break;
                case PrestacaoStatusEnum.Finalizada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                case PrestacaoStatusEnum.Rejeitada:
                    prestacao = _repository.GetById(prestacaoId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoAprovacao), tipoAprovacao, null);
            }

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatusEnum)prestacao.StatusId);
            _emailHelper.EnviarEmail(prestacao, (PrestacaoStatusEnum)prestacao.StatusId, emailTo);
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

        private string GetEmailTo(Prestacao prestacao, PrestacaoStatusEnum statusAtual)
        {
            switch (statusAtual)
            {
                case PrestacaoStatusEnum.EmAprovacaoOperacional:
                    return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorId);
                case PrestacaoStatusEnum.EmAprovacaoFinanceira:
                    return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId);
                case PrestacaoStatusEnum.Rejeitada:
                case PrestacaoStatusEnum.Finalizada:
                    return _usuarioService.GetUsuarioEmailById(prestacao.EmitenteId);
            }

            return string.Empty;
        }
    }
}
