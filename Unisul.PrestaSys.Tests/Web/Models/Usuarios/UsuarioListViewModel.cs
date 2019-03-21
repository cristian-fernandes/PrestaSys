using System.Collections.Generic;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Usuarios;

namespace Unisul.PrestaSys.Tests.Web.Models.Usuarios
{
    [TestClass]
    public class UsuarioListViewModelTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            const int pageNumber = 84;
            const int totalRecords = 50;
            var usuarioList = new List<UsuarioViewModel>();
            var loginViewModel = new UsuarioListViewModel { UsuariosList = usuarioList, TotalRecords = totalRecords, PageNumber = pageNumber};

            loginViewModel.UsuariosList.IsSameOrEqualTo(usuarioList);
            loginViewModel.TotalRecords.IsSameOrEqualTo(totalRecords);
            loginViewModel.PageNumber.IsSameOrEqualTo(pageNumber);
        }
    }
}
