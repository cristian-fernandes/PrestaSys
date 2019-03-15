using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Tests.Entidades.Prestacoes
{
    [TestClass]
    public class PrestacaoStatusTests
    {
        private const string Status = "Finalizada";
        private const int Id = 1;

        [TestMethod]
        public void PrestacaoStatusPropertiesShouldBePopulatedOnCtor()
        {
            var prestacaoStatus = new PrestacaoStatus();

            Assert.IsNotNull(prestacaoStatus.Prestacao);
        }

        [TestMethod]
        public void PrestacaoStatusPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var prestacaoStatus = new PrestacaoStatus();

            prestacaoStatus.Status = Status;
            prestacaoStatus.Id = Id;

            Assert.AreEqual(prestacaoStatus.Status, Status);
        }
    }
}
