using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoTipo
    {
        public PrestacaoTipo()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        [Key]
        public int Id { get; set; }

        public ICollection<Prestacao> Prestacao { get; set; }

        public string Tipo { get; set; }
    }
}
