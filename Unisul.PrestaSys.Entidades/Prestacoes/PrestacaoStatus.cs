using System.Collections.Generic;
using Unisul.PrestaSys.Comum;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoStatus : IEntity
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
