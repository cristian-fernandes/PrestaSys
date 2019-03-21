using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Web.Controllers;
using Unisul.PrestaSys.Web.Models.Home;

namespace Unisul.PrestaSys.Tests.Web.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ErrorShouldReturnViewWithModel()
        {
            var homeController = new HomeController(Mock.Of<IUsuarioService>());

            var result = homeController.Error();

            result.Should().BeOfType<ViewResult>();
            var resultView = result as ViewResult;
            var model = resultView?.Model as ErrorViewModel;
            model?.RequestId.Should().NotBeEmpty();
        }

        [TestMethod]
        public void IndexShouldReturnView()
        {
            var homeController = new HomeController(Mock.Of<IUsuarioService>());

            var result = homeController.Index();

            result.Should().BeOfType<ViewResult>();
        }
    }
}
