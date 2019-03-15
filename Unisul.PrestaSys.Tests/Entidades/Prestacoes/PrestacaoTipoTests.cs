using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Tests.Entidades.Prestacoes
{
    [TestClass]
    public class PrestacaoTipoTests
    {
        private const string Tipo = "Uber";
        private const int Id = 1;

        [TestMethod]
        public void PrestacaoTipoPropertiesShouldBePopulatedOnCtor()
        {
            var prestacaoTipo = new PrestacaoTipo();

            Assert.IsNotNull(prestacaoTipo.Prestacao);
        }

        [TestMethod]
        public void PrestacaoTipoPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var prestacaoTipo = new PrestacaoTipo();

            prestacaoTipo.Tipo = Tipo;
            prestacaoTipo.Id = Id;

            Assert.AreEqual(prestacaoTipo.Tipo, Tipo);
        }
    }
}
