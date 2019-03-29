using System.Linq;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions
{
    public interface IPrestacaoStatusActions
    {
        void AprovarPrestacao(Prestacao prestacao, string justificativa);
        IQueryable<Prestacao> GetAllParaAprovacao(int aprovadorId);
        void RejeitarPrestacao(Prestacao prestacao, string justificativa);
        string GetEmailTo(Prestacao prestacao);
    }
}
