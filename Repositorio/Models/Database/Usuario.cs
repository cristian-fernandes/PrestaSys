using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Models.Database
{
    public class Usuario
    {
        public Usuario()
        {
            InverseGerente = new HashSet<Usuario>();
            InverseGerenteFinanceiro = new HashSet<Usuario>();
            PrestacaoAprovador = new HashSet<Prestacao>();
            PrestacaoAprovadorFinanceiro = new HashSet<Prestacao>();
            PrestacaoEmitente = new HashSet<Prestacao>();
        }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "É Gerente?")]
        public bool FlagGerente { get; set; }

        [Display(Name = "É Gerente Financeiro?")]
        public bool FlagGerenteFinanceiro { get; set; }

        [Display(Name = "Gerente")]
        public virtual Usuario Gerente { get; set; }

        [Display(Name = "Gerente Financeiro")]
        public virtual Usuario GerenteFinanceiro { get; set; }

        [Display(Name = "Gerente Financeiro")]
        public int? GerenteFinanceiroId { get; set; }

        [Display(Name = "Gerente")]
        public int? GerenteId { get; set; }

        public int Id { get; set; }
        public virtual ICollection<Usuario> InverseGerente { get; set; }
        public virtual ICollection<Usuario> InverseGerenteFinanceiro { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Prestacao> PrestacaoAprovador { get; set; }
        public virtual ICollection<Prestacao> PrestacaoAprovadorFinanceiro { get; set; }
        public virtual ICollection<Prestacao> PrestacaoEmitente { get; set; }
        public string Senha { get; set; }
        public string Sobrenome { get; set; }
    }
}
