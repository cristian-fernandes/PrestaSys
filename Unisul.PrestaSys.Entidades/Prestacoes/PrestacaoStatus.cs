using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public sealed class PrestacaoStatus
    {
        public PrestacaoStatus()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        [Key]
        public int Id { get; set; }

        public ICollection<Prestacao> Prestacao { get; set; }
       
        public string Status { get; set; }
    }
}
