using System.Collections.Generic;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoStatus
    {
        public PrestacaoStatus()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }

        public ICollection<Prestacao> Prestacao { get; set; }
       
        public string Status { get; set; }
    }
}
