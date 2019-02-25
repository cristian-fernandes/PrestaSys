using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorio.Models.Database
{
    public class Prestacao
    {
        public virtual Usuario Aprovador { get; set; }
        public virtual Usuario AprovadorFinanceiro { get; set; }
        public int AprovadorFinanceiroId { get; set; }
        public int AprovadorId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public virtual Usuario Emitente { get; set; }
        [Display(Name = "Emitente")]
        public int EmitenteId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Comprovante das Despesas")]
        public byte[] ImagemComprovante { get; set; }
        public string Justificativa { get; set; }
        [Display(Name = "Justificativa para Aprovação/Rejeição")]
        public string JustificativaAprovacao { get; set; }
        [Display(Name = "Justificativa para Aprovação/Rejeição do Financeiro")]
        public string JustificativaAprovacaoFinanceira { get; set; }
        public virtual PrestacaoStatus Status { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public virtual PrestacaoTipo Tipo { get; set; }
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }
        [Display(Name = "Título da Prestação")]
        public string Titulo { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
    }
}
