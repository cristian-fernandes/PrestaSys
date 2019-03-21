using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Tests.Web.Models.Base
{
    [TestClass]
    public class DadosLoginTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            const string email = "aaa@bbb.com";
            const string nome = "abacate";
            const string sobrenome = "sadsad";
            const bool flagGerente = true;
            const bool flagGerenteFinanceiro = true;

            var dadosLogin = new DadosLogin
            {
                Email = email, Nome = nome, Sobrenome = sobrenome, FlagGerente = flagGerente,
                FlagGerenteFinanceiro = flagGerenteFinanceiro
            };

            dadosLogin.Email.IsSameOrEqualTo(email);
            dadosLogin.Nome.IsSameOrEqualTo(nome);
            dadosLogin.Sobrenome.IsSameOrEqualTo(sobrenome);
            dadosLogin.FlagGerente.IsSameOrEqualTo(flagGerente);
            dadosLogin.FlagGerenteFinanceiro.IsSameOrEqualTo(flagGerenteFinanceiro);
        }
    }
}
