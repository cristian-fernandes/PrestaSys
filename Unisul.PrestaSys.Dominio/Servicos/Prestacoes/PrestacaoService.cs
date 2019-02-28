using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Comum;
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
        int Update(Prestacao usuario);
        IQueryable<PrestacaoTipo> GetAllPrestacaoTipos();
    }

    public class PrestacaoService : IPrestacaoService
    {
        private readonly IPrestacaoRepository _repository;

        public PrestacaoService(IPrestacaoRepository repository)
        {
            _repository = repository;
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

            return _repository.Update(prestacao);
        }

        public int Create(Prestacao prestacao)
        {
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

            return _repository.Update(prestacao);
        }

        public int Update(Prestacao usuario)
        {
            return _repository.Update(usuario);
        }

        public IQueryable<PrestacaoTipo> GetAllPrestacaoTipos()
        {
            return _repository.GetAllPrestacaoTipos();
        }
    }
}
