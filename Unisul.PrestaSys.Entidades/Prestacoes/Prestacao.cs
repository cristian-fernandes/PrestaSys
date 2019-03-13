using System;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Entidades.Prestacoes
{
    public class Prestacao : IEntity
    {
        public virtual Usuario Aprovador { get; set; }

        public virtual Usuario AprovadorFinanceiro { get; set; }

        public int AprovadorFinanceiroId { get; set; }

        public int AprovadorId { get; set; }

        public DateTime Data { get; set; }

        public virtual Usuario Emitente { get; set; }

        public int EmitenteId { get; set; }

        public int Id { get; set; }

        public byte[] ImagemComprovante { get; set; }

        public string Justificativa { get; set; }

        public string JustificativaAprovacao { get; set; }

        public string JustificativaAprovacaoFinanceira { get; set; }

        public virtual PrestacaoStatus Status { get; set; }

        public int StatusId { get; set; }

        public virtual PrestacaoTipo Tipo { get; set; }

        public int TipoId { get; set; }

        public string Titulo { get; set; }

        public decimal Valor { get; set; }
    }
}
