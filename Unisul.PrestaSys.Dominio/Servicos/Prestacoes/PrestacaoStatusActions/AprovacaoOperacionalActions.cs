using System.Linq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public class AprovacaoOperacionalActions : IPrestacaoStatusActions
    {
        private readonly IPrestacaoRepository _repository;
        private readonly IUsuarioService _usuarioService;

        public AprovacaoOperacionalActions(IPrestacaoRepository repository, IUsuarioService usuarioService)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        public void AprovarPrestacao(Prestacao prestacao, string justificativa)
        {
            prestacao.StatusId = (int)PrestacaoStatuses.EmAprovacaoFinanceira;
            prestacao.JustificativaAprovacao = justificativa;
        }

        public IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId)
        {
            return _repository.GetAll().Where(pr =>
                pr.AprovadorId == aprovadorId &&
                pr.StatusId == (int)PrestacaoStatuses.EmAprovacaoOperacional);
        }

        public void RejeitarPrestacao(Prestacao prestacao, string justificativa)
        {
            prestacao.StatusId = (int)PrestacaoStatuses.Rejeitada;
            prestacao.JustificativaAprovacao = justificativa;
        }

        public string GetEmailTo(Prestacao prestacao)
        {
            return _usuarioService.GetUsuarioEmailById(prestacao.AprovadorId);
        }

        public string GetEmailBody(string emailText)
        {
            emailText = emailText.Replace("{{STATUS}}", "Aguardando Aprova&ccedil;&atilde;o Operacional");
            emailText = emailText.Replace("{{FRASE_FINAL}}",
                "Favor verificar a sua lista de presta&ccedil;&otilde;es pendentes de aprova&ccedil;&atilde;o.");

            return emailText;
        }
    }
}
