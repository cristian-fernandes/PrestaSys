using System;
using System.Linq;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public class RejeitadaActions : IPrestacaoStatusActions
    {
        private readonly IUsuarioService _usuarioService;

        public RejeitadaActions(IPrestacaoRepository repository, IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void AprovarPrestacao(Prestacao prestacao, string justificativa)
        {
            throw  new NotSupportedException();
        }

        public IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId)
        {
            throw new NotSupportedException();
        }

        public void RejeitarPrestacao(Prestacao prestacao, string justificativa)
        {
            throw new NotSupportedException();
        }

        public string GetEmailTo(Prestacao prestacao)
        {
            return _usuarioService.GetUsuarioEmailById(prestacao.EmitenteId);
        }

        public string GetEmailBody(string emailText)
        {
            emailText = emailText.Replace("{{STATUS}}", "Rejeitada");
            emailText = emailText.Replace("{{FRASE_FINAL}}",
                "Favor verificar a sua lista de presta&ccedil;&otilde;es criadas.");

            return emailText;
        }
    }
}
