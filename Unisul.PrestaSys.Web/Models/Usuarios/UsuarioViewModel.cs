using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "É Gerente?")]
        public bool FlagGerente { get; set; }

        [Display(Name = "É Gerente Financeiro?")]
        public bool FlagGerenteFinanceiro { get; set; }

        [Display(Name = "Gerente")]
        public Usuario Gerente { get; set; }

        [Display(Name = "Gerente Financeiro")]
        public Usuario GerenteFinanceiro { get; set; }

        [Display(Name = "Gerente Financeiro")]
        public int? GerenteFinanceiroId { get; set; }

        [Display(Name = "Gerente")]
        public int? GerenteId { get; set; }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Sobrenome { get; set; }

        public SelectList GerenteSelectList { get; set; }

        public SelectList GerenteFinanceiroSelectList { get; set; }
    }
}
