using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Web.Models.Prestacoes;

namespace Unisul.PrestaSys.Tests.Web.Models.Prestacoes
{
    [TestClass]
    public class PrestacaoViewModelTests
    {
        [TestMethod]
        public void ShouldLockPrestacaoShouldBeFalse()
        {
            var prestacaoViewModel = new PrestacaoViewModel {StatusId = (int) PrestacaoStatuses.EmAprovacaoOperacional};

            prestacaoViewModel.ShouldLockPrestacao.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldLockPrestacaoShouldBeTrue()
        {
            var prestacaoViewModel = new PrestacaoViewModel {StatusId = (int) PrestacaoStatuses.Finalizada};

            prestacaoViewModel.ShouldLockPrestacao.Should().BeTrue();
        }
    }
}
