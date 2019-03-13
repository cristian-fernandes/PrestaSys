using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Prestacoes
{
    public class PrestacaoViewModel : BaseViewModel
    {
        public Usuario Aprovador { get; set; }

        [Display(Name = "Aprovador Financeiro")]
        public Usuario AprovadorFinanceiro { get; set; }

        [Required] public int AprovadorFinanceiroId { get; set; }

        [Required] public int AprovadorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Por favor, informe a data da prestação.")]
        public DateTime Data { get; set; }

        public Usuario Emitente { get; set; }

        [Display(Name = "Emitente")]
        [Required]
        public int EmitenteId { get; set; }

        public int Id { get; set; }

        [Display(Name = "Comprovante das Despesas")]
        public IFormFile ImagemComprovante { get; set; }

        public string ImagemComprovanteSrc { get; set; }

        [Required(ErrorMessage = "Por favor, informe a justificativa para a prestação.")]
        public string Justificativa { get; set; }

        [Display(Name = "Justificativa para Aprovação/Rejeição")]
        public string JustificativaAprovacao { get; set; }

        [Display(Name = "Justificativa para Aprovação/Rejeição do Financeiro")]
        public string JustificativaAprovacaoFinanceira { get; set; }

        public PrestacaoStatus Status { get; set; }

        [Required] [Display(Name = "Status")] public int StatusId { get; set; }

        public PrestacaoTipo Tipo { get; set; }

        [Required] [Display(Name = "Tipo")] public int TipoId { get; set; }

        public SelectList TipoPrestacaoSelectList { get; set; }

        [Required(ErrorMessage = "Por favor, informe o título da prestação.")]
        [Display(Name = "Título da Prestação")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor da prestação.")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public bool ShouldLockPrestacao => Status?.Id == (int) PrestacaoStatusEnum.Finalizada;
    }
}
