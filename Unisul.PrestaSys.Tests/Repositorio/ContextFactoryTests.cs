using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Repositorio;

namespace Unisul.PrestaSys.Tests.Repositorio
{
    [TestClass]
    public class ContextFactoryTests
    {
        [TestMethod]
        public void ShouldCreateDbContextWithArgs()
        {
            var contextFactory = new ContextFactory();

            var result = contextFactory.CreateDbContext(new string[0]);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(PrestaSysDbContext));
        }

        [TestMethod]
        public void ShouldCreateDbContextWithoutArgs()
        {
            var contextFactory = new ContextFactory();

            var result = contextFactory.CreateDbContext();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(PrestaSysDbContext));
        }
    }
}
