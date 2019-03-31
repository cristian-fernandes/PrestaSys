using System.Linq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public class AprovacaoFinanceiraActions : IPrestacaoStatusActions
    {
        private readonly IPrestacaoRepository _repository;
        private readonly IUsuarioService _usuarioService;

        public AprovacaoFinanceiraActions(IPrestacaoRepository repository, IUsuarioService usuarioService)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        public void AprovarPrestacao(Prestacao prestacao, string justificativa)
        {
            prestacao.StatusId = (int)PrestacaoStatuses.Finalizada;
            prestacao.JustificativaAprovacaoFinanceira = justificativa;
        }

        public IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId)
        {
            return _repository.GetAll().Where(pr =>
                pr.AprovadorFinanceiroId == aprovadorId &&
                pr.StatusId == (int)PrestacaoStatuses.EmAprovacaoFinanceira);
        }

        public void RejeitarPrestacao(Prestacao prestacao, string justificativa)
        {
            prestacao.StatusId = (int)PrestacaoStatuses.Rejeitada;
            prestacao.JustificativaAprovacaoFinanceira = justificativa;
        }

        public string GetEmailTo(Prestacao prestacao)
        {
            return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId);
        }

        public string GetEmailBody(string emailText)
        {
            emailText = emailText.Replace("{{STATUS}}", "Aguardando Aprova&ccedil;&atilde;o Financeira");
            emailText = emailText.Replace("{{FRASE_FINAL}}",
                "Favor verificar a sua lista de presta&ccedil;&otilde;es pendentes de aprova&ccedil;&atilde;o financeira.");

            return emailText;
        }
    }
}
