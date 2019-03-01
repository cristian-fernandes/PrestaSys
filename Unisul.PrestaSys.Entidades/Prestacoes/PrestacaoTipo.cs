using System.Collections.Generic;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoTipo
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
