using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Web.Models.Usuarios;

namespace Unisul.PrestaSys.Tests.Web.Models.Usuarios
{
    [TestClass]
    public class UsuarioViewModelTests
    {
        [TestMethod]
        public void ShouldDisableDeleteButtonShouldBeTrue()
        {
            var prestacaoViewModel = new UsuarioViewModel { PrestacaoAprovador = new List<Prestacao>{ new Prestacao() }};

            prestacaoViewModel.ShouldDisableDeleteButton.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldLockPrestacaoShouldBeTrue()
        {
            var prestacaoViewModel = new UsuarioViewModel();

            prestacaoViewModel.ShouldDisableDeleteButton.Should().BeFalse();
        }
    }
}
