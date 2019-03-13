using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Unisul.PrestaSys.Entidades.Prestacoes;
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

        [Display(Name = "Gerente")] public Usuario Gerente { get; set; }

        [Display(Name = "Gerente Financeiro")] public Usuario GerenteFinanceiro { get; set; }

        [Required]
        [Display(Name = "Gerente Financeiro")]
        public int? GerenteFinanceiroId { get; set; }

        public SelectList GerenteFinanceiroSelectList { get; set; }

        [Required] [Display(Name = "Gerente")] public int? GerenteId { get; set; }

        public SelectList GerenteSelectList { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        public ICollection<Prestacao> PrestacaoAprovador { get; set; }

        public ICollection<Prestacao> PrestacaoAprovadorFinanceiro { get; set; }

        public ICollection<Prestacao> PrestacaoEmitente { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }

        public bool ShouldDisableDeleteButton => PrestacaoAprovador != null && PrestacaoAprovador.Any() ||
                                                 PrestacaoAprovadorFinanceiro != null &&
                                                 PrestacaoAprovadorFinanceiro.Any();

        [Required(ErrorMessage = "Por favor, informe o sobrenome do usuário.")]
        public string Sobrenome { get; set; }
    }
}
