using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public interface IPrestacaoStatusActionsFactory
    {
        IPrestacaoStatusActions CreateObject(PrestacaoStatuses status);
    }

    public class PrestacaoStatusActionsFactory
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
                case PrestacaoStatuses.Rejeitada:
                    return new SemAprovacaoActions(_repository, _usuarioService);
            }

            return new SemAprovacaoActions(_repository, _usuarioService);
        }
    }
}
