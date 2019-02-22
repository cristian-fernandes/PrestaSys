using System;
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Models.Database
{
    public class Prestacao
    {
        public virtual Usuario Aprovador { get; set; }
        public virtual Usuario AprovadorFinanceiro { get; set; }
        public int AprovadorFinanceiroId { get; set; }
        public int AprovadorId { get; set; }
        public DateTime Data { get; set; }
        public virtual Usuario Emitente { get; set; }
        [Display(Name = "Emitente")]
        public int EmitenteId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Comprovante das Despesas")]
        public byte[] ImagemComprovante { get; set; }
        public string Justificativa { get; set; }
        public virtual PrestacaoStatus Status { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public virtual PrestacaoTipo Tipo { get; set; }
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }
        [Display(Name = "Título da Prestação")]
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
    }
}
