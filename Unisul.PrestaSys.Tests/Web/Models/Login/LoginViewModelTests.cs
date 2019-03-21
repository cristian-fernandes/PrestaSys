using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Login;

namespace Unisul.PrestaSys.Tests.Web.Models.Login
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            const string email = "aaa@bbb.com";
            const string senha = "abacate";
            var loginViewModel = new LoginViewModel {Email = email, Senha = senha };

            loginViewModel.Email.IsSameOrEqualTo(email);
            loginViewModel.Senha.IsSameOrEqualTo(senha);
        }
    }
}
