using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Home;

namespace Unisul.PrestaSys.Tests.Web.Models.Home
{
    [TestClass]
    public class ErrorViewModelTests
    {
        [TestMethod]
        public void ShowRequestIdShouldBeTrue()
        {
            var errorViewModel = new ErrorViewModel {RequestId = "RequestID"};

            errorViewModel.ShowRequestId.Should().BeTrue();
        }

        [TestMethod]
        public void ShowRequestIdShouldBeFalse()
        {
            var errorViewModel = new ErrorViewModel();

            errorViewModel.ShowRequestId.Should().BeFalse();
        }
    }
}
