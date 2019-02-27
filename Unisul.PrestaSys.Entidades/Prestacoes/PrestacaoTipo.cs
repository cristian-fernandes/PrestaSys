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

        public int Id { get; set; }

        public ICollection<Prestacao> Prestacao { get; set; }

        [Display(Name = "Tipo da Prestação")]
        public string Tipo { get; set; }
    }
}
