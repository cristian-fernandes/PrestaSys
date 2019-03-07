using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Por favor, informe um e-mail válido.")]
        [Required(ErrorMessage = "Por favor, informe o e-mail do usuário.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "É Gerente?")]
        public bool FlagGerente { get; set; }

        [Required]
        [Display(Name = "É Gerente Financeiro?")]
        public bool FlagGerenteFinanceiro { get; set; }

        [Display(Name = "Gerente")]
        public Usuario Gerente { get; set; }

        [Display(Name = "Gerente Financeiro")]
        public Usuario GerenteFinanceiro { get; set; }

        [Required]
        [Display(Name = "Gerente Financeiro")]
        public int? GerenteFinanceiroId { get; set; }

        [Required]
        [Display(Name = "Gerente")]
        public int? GerenteId { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sobrenome do usuário.")]
        public string Sobrenome { get; set; }

        public SelectList GerenteSelectList { get; set; }

        public SelectList GerenteFinanceiroSelectList { get; set; }
    }
}
