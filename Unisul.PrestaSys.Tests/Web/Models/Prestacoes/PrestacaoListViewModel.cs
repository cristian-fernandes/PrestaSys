using System.Collections.Generic;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Web.Models.Prestacoes;

namespace Unisul.PrestaSys.Tests.Web.Models.Prestacoes
{
    [TestClass]
    public class PrestacaoListViewModelTests
    {
        [TestMethod]
        public void ShouldHaveAllProperties()
        {
            const int pageNumber = 84;
            const int totalRecords = 50;
            const string tipoListagem = "A";
            var prestacaoList = new List<PrestacaoViewModel>();
            var loginViewModel = new PrestacaoListViewModel{ PrestacoesList = prestacaoList, TotalRecords = totalRecords, PageNumber = pageNumber, TipoListagem = tipoListagem};

            loginViewModel.PrestacoesList.IsSameOrEqualTo(prestacaoList);
            loginViewModel.TotalRecords.IsSameOrEqualTo(totalRecords);
            loginViewModel.PageNumber.IsSameOrEqualTo(pageNumber);
            loginViewModel.TipoListagem.IsSameOrEqualTo(tipoListagem);
        }
    }
}
