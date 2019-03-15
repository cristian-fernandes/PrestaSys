using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Tests.Entidades.Usuarios
{
    [TestClass]
    public class UsuarioTests
    {
        private const string Email = "test@test.com";
        private const bool FlagGerente = true;
        private const bool FlagGerenteFinanceiro = true;
        private const int GerenteFinanceiroId = 1;
        private const int GerenteId = 1;
        private const int Id = 1;
        private const string Nome = "Cristian";
        private const string Senha = "abacate";
        private const string Sobrenome = "Fernandes";
        private static readonly Usuario Gerente = new Usuario();
        private static readonly Usuario GerenteFinanceiro = new Usuario();

        [TestMethod]
        public void UsuarioPropertiesShouldBePopulatedOnCtor()
        {
            var usuario = new Usuario();

            Assert.IsNotNull(usuario.InverseGerente);
            Assert.IsNotNull(usuario.InverseGerenteFinanceiro);
            Assert.IsNotNull(usuario.PrestacaoAprovador);
            Assert.IsNotNull(usuario.PrestacaoAprovadorFinanceiro);
            Assert.IsNotNull(usuario.PrestacaoEmitente);
        }

        [TestMethod]
        public void UsuarioPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var usuario = new Usuario();

            usuario.Email = Email;
            usuario.FlagGerente = FlagGerente;
            usuario.FlagGerenteFinanceiro = FlagGerenteFinanceiro;
            usuario.Gerente = Gerente;
            usuario.GerenteFinanceiro = GerenteFinanceiro;
            usuario.GerenteFinanceiroId = GerenteFinanceiroId;
            usuario.GerenteId = GerenteId;
            usuario.Id = Id;
            usuario.Nome = Nome;
            usuario.Senha = Senha;
            usuario.Sobrenome = Sobrenome;

            Assert.AreEqual(usuario.Email, Email);
            Assert.AreEqual(usuario.FlagGerente, FlagGerente);
            Assert.AreEqual(usuario.FlagGerenteFinanceiro, FlagGerenteFinanceiro);
            Assert.AreEqual(usuario.Gerente, Gerente);
            Assert.AreEqual(usuario.GerenteFinanceiro, GerenteFinanceiro);
            Assert.AreEqual(usuario.GerenteFinanceiroId, GerenteFinanceiroId);
            Assert.AreEqual(usuario.GerenteId, GerenteId);
            Assert.AreEqual(usuario.Id, Id);
            Assert.AreEqual(usuario.Nome, Nome);
            Assert.AreEqual(usuario.Senha, Senha);
            Assert.AreEqual(usuario.Sobrenome, Sobrenome);
        }
    }
}
