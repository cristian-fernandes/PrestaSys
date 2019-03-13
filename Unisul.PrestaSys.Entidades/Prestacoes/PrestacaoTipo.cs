using System.Collections.Generic;
using Unisul.PrestaSys.Comum;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoTipo : IEntity
    {
        public PrestacaoTipo()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }

        public ICollection<Prestacao> Prestacao { get; set; }

        public string Tipo { get; set; }
    }
}
