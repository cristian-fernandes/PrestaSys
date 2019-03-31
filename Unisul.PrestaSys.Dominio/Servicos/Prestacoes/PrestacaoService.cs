using System.Collections.Generic;
using System.Linq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Email;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions;
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
        private readonly IEmailService _emailService;
        private readonly IPrestacaoRepository _repository;
        private readonly IPrestacaoStatusActionsFactory _prestacaoStatusActionsFactory;

        public PrestacaoService(IPrestacaoRepository repository, IEmailService emailService,
            IPrestacaoStatusActionsFactory prestacaoStatusActionsFactory)
        {
            _repository = repository;
            _emailService = emailService;
            _prestacaoStatusActionsFactory = prestacaoStatusActionsFactory;
        }

        public int AprovarPrestacao(int prestacaoId, string justificativa, PrestacaoStatuses tipoAprovacao)
        {
            var prestacao = _repository.GetById(prestacaoId);

            _prestacaoStatusActionsFactory.CreateObject(tipoAprovacao).AprovarPrestacao(prestacao, justificativa);

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses) prestacao.StatusId);
            _emailService.EnviarEmail(prestacao, (PrestacaoStatuses) prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Create(Prestacao prestacao)
        {
            var emailTo = GetEmailTo(prestacao, PrestacaoStatuses.EmAprovacaoOperacional);
            _emailService.EnviarEmail(prestacao, PrestacaoStatuses.EmAprovacaoOperacional, emailTo);
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
            return _prestacaoStatusActionsFactory.CreateObject(tipoAprovacao).GetAllParaAprovacao(aprovadorId);
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

            _prestacaoStatusActionsFactory.CreateObject(tipoAprovacao).RejeitarPrestacao(prestacao, justificativa);

            var emailTo = GetEmailTo(prestacao, (PrestacaoStatuses) prestacao.StatusId);
            _emailService.EnviarEmail(prestacao, (PrestacaoStatuses) prestacao.StatusId, emailTo);
            return _repository.Update(prestacao);
        }

        public int Update(Prestacao prestacao)
        {
            return _repository.Update(prestacao);
        }

        public string GetEmailTo(Prestacao prestacao, PrestacaoStatuses statusAtual)
        {
            return _prestacaoStatusActionsFactory.CreateObject(statusAtual).GetEmailTo(prestacao);
        }
    }
}
