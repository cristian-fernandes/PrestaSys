using System.Collections.Generic;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Prestacoes;

namespace Unisul.PrestaSys.Tests.Web.Models.Usuarios
{
    [TestClass]
    public class PrestacaoListViewModelTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            const int pageNumber = 84;
            const int totalRecords = 50;
            var prestacaoList = new List<PrestacaoViewModel>();
            var loginViewModel = new PrestacaoListViewModel{ PrestacoesList = prestacaoList, TotalRecords = totalRecords, PageNumber = pageNumber};

            loginViewModel.PrestacoesList.IsSameOrEqualTo(prestacaoList);
            loginViewModel.TotalRecords.IsSameOrEqualTo(totalRecords);
            loginViewModel.PageNumber.IsSameOrEqualTo(pageNumber);
        }
    }
}
