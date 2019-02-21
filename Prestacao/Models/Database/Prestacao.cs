using System;
using System.Collections.Generic;

namespace Prestacao.Models.Database
{
    public partial class Prestacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Justificativa { get; set; }
        public DateTime Data { get; set; }
        public byte[] ImagemComprovante { get; set; }
        public decimal Valor { get; set; }
        public int StatusId { get; set; }
        public int TipoId { get; set; }
        public int EmitenteId { get; set; }
        public int AprovadorId { get; set; }
        public int AprovadorFinanceiroId { get; set; }

        public virtual Usuario Aprovador { get; set; }
        public virtual Usuario AprovadorFinanceiro { get; set; }
        public virtual Usuario Emitente { get; set; }
        public virtual PrestacaoStatus Status { get; set; }
        public virtual PrestacaoTipo Tipo { get; set; }
    }
}
