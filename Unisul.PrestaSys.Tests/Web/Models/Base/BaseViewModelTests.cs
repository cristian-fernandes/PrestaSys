using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Tests.Web.Models.Base
{
    [TestClass]
    public class BaseViewModelTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            var usuarioLogado = new DadosLogin();
            var loginViewModel = new BaseViewModel {UsuarioLogado = usuarioLogado };

            loginViewModel.UsuarioLogado.IsSameOrEqualTo(usuarioLogado);
        }
    }
}
