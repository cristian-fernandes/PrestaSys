using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Models.Database
{
    public class PrestacaoTipo
    {
        public PrestacaoTipo()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }

        public virtual ICollection<Prestacao> Prestacao { get; set; }
        [Display(Name = "Tipo da Prestação")]
        public string Tipo { get; set; }
    }
}
