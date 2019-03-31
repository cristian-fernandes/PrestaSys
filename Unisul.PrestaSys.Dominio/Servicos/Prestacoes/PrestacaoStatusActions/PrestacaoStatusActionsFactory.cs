using System;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public interface IPrestacaoStatusActionsFactory
    {
        IPrestacaoStatusActions CreateObject(PrestacaoStatuses status);
    }

    public class PrestacaoStatusActionsFactory : IPrestacaoStatusActionsFactory
    {
        private readonly IPrestacaoRepository _repository;
        private readonly IUsuarioService _usuarioService;

        public PrestacaoStatusActionsFactory(IPrestacaoRepository repository, IUsuarioService usuarioService)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        public IPrestacaoStatusActions CreateObject(PrestacaoStatuses status)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (status)
            {
                case PrestacaoStatuses.EmAprovacaoOperacional:
                    return new AprovacaoOperacionalActions(_repository, _usuarioService);
                case PrestacaoStatuses.EmAprovacaoFinanceira:
                    return new AprovacaoFinanceiraActions(_repository, _usuarioService);
                case PrestacaoStatuses.Finalizada:
                    return new FinalizadaActions(_repository, _usuarioService);
                case PrestacaoStatuses.Rejeitada:
                    return new RejeitadaActions(_repository, _usuarioService);
            }

            throw new NotSupportedException();
        }
    }
}
