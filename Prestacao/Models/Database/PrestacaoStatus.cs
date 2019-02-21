using System;
using System.Collections.Generic;

namespace Prestacao.Models.Database
{
    public partial class PrestacaoStatus
    {
        public PrestacaoStatus()
        {
            Prestacao = new HashSet<Prestacao>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Prestacao> Prestacao { get; set; }
    }
}
