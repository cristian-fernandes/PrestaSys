using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Tests.Entidades
{
    [TestClass]
    public class UsuarioTests
    {
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
    }
}
