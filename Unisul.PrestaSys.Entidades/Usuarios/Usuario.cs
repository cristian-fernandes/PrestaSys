using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Entidades.Usuarios
{
    public sealed class Usuario
    {
        public Usuario()
        {
            InverseGerente = new HashSet<Usuario>();
            InverseGerenteFinanceiro = new HashSet<Usuario>();
            PrestacaoAprovador = new HashSet<Prestacao>();
            PrestacaoAprovadorFinanceiro = new HashSet<Prestacao>();
            PrestacaoEmitente = new HashSet<Prestacoes.Prestacao>();
        }

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

        public ICollection<Usuario> InverseGerente { get; set; }

        public ICollection<Usuario> InverseGerenteFinanceiro { get; set; }

        public string Nome { get; set; }

        public ICollection<Prestacao> PrestacaoAprovador { get; set; }

        public ICollection<Prestacao> PrestacaoAprovadorFinanceiro { get; set; }

        public ICollection<Prestacao> PrestacaoEmitente { get; set; }

        public string Senha { get; set; }

        public string Sobrenome { get; set; }

    }
}
