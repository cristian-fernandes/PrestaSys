using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prestacao.Models.Database
{
    public partial class Usuario
    {
        public Usuario()
        {
            InverseGerente = new HashSet<Usuario>();
            InverseGerenteFinanceiro = new HashSet<Usuario>();
            PrestacaoAprovador = new HashSet<Prestacao>();
            PrestacaoAprovadorFinanceiro = new HashSet<Prestacao>();
            PrestacaoEmitente = new HashSet<Prestacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool FlagGerente { get; set; }
        public bool FlagGerenteFinanceiro { get; set; }
        public int? GerenteId { get; set; }
        public int? GerenteFinanceiroId { get; set; }

        [Display(Name = "Gerente")]
        public virtual Usuario Gerente { get; set; }
        [Display(Name = "Gerente Financeiro")]
        public virtual Usuario GerenteFinanceiro { get; set; }
        public virtual ICollection<Usuario> InverseGerente { get; set; }
        public virtual ICollection<Usuario> InverseGerenteFinanceiro { get; set; }
        public virtual ICollection<Prestacao> PrestacaoAprovador { get; set; }
        public virtual ICollection<Prestacao> PrestacaoAprovadorFinanceiro { get; set; }
        public virtual ICollection<Prestacao> PrestacaoEmitente { get; set; }
    }
}
