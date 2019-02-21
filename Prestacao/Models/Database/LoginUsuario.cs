using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestacao.Models.Database
{
    public class LoginUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool FlagGerente { get; set; }
        public bool FlagGerenteFinanceiro { get; set; }
    }
}
