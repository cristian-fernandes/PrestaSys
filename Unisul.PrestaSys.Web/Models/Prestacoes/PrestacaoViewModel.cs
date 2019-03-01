using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Prestacoes
{
    public class PrestacaoViewModel : BaseViewModel
    {
        public int AprovadorFinanceiroId { get; set; }

        public int AprovadorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Emitente")]
        public int EmitenteId { get; set; }

        public int Id { get; set; }

        [Display(Name = "Comprovante das Despesas")]
        public IFormFile ImagemComprovante { get; set; }

        public string ImagemComprovanteSrc { get; set; }

        public string Justificativa { get; set; }

        [Display(Name = "Justificativa para Aprovação/Rejeição")]
        public string JustificativaAprovacao { get; set; }

        [Display(Name = "Justificativa para Aprovação/Rejeição do Financeiro")]
        public string JustificativaAprovacaoFinanceira { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        public PrestacaoStatus Status { get; set; }

        public PrestacaoTipo Tipo { get; set; }

        [Display(Name = "Título da Prestação")]
        public string Titulo { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public Usuario Aprovador { get; set; }

        [Display(Name = "Aprovador Financeiro")]
        public Usuario AprovadorFinanceiro { get; set; }

        public Usuario Emitente { get; set; }

        public SelectList TipoPrestacaoSelectList { get; set; }
    }
}
