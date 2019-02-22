using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Models.Database
{
    public class PrestacaoStatus
    {
        public PrestacaoStatus()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }

        public virtual ICollection<Prestacao> Prestacao { get; set; }
        [Display(Name = "Status da Prestação")]
        public string Status { get; set; }
    }
}
