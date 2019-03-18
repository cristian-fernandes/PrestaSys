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
            PrestacaoEmitente = new HashSet<Prestacao>();
        }

        public string Email { get; set; }

        public bool FlagGerente { get; set; }

        public bool FlagGerenteFinanceiro { get; set; }

        public Usuario Gerente { get; set; }

        public Usuario GerenteFinanceiro { get; set; }

        public int GerenteFinanceiroId { get; set; }

        public int GerenteId { get; set; }

        [Key]
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
