using System;
using System.Collections.Generic;

namespace Prestacao.Models.Database
{
    public partial class PrestacaoTipo
    {
        public PrestacaoTipo()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Prestacao> Prestacao { get; set; }
    }
}
