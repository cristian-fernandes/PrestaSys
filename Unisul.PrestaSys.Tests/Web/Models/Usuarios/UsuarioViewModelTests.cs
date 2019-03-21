using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Usuarios;

namespace Unisul.PrestaSys.Tests.Web.Models.Usuarios
{
    [TestClass]
    public class UsuarioViewModelTests
    {
        private const string Email = "test@test.com";
        private const bool FlagGerente = true;
        private const bool FlagGerenteFinanceiro = true;
        private const int GerenteFinanceiroId = 1;
        private const int GerenteId = 1;
        private const int Id = 1;
        private const string Nome = "Cristian";
        private const string Senha = "abacate";
        private const string Sobrenome = "Fernandes";
        private static readonly Usuario Gerente = new Usuario();
        private static readonly Usuario GerenteFinanceiro = new Usuario();

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

        [TestMethod]
        public void UsuarioViewModelPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var usuario = new UsuarioViewModel
            {
                Email = Email,
                FlagGerente = FlagGerente,
                FlagGerenteFinanceiro = FlagGerenteFinanceiro,
                Gerente = Gerente,
                GerenteFinanceiro = GerenteFinanceiro,
                GerenteFinanceiroId = GerenteFinanceiroId,
                GerenteId = GerenteId,
                Id = Id,
                Nome = Nome,
                Senha = Senha,
                Sobrenome = Sobrenome
            };

            Assert.AreEqual(usuario.Email, Email);
            Assert.AreEqual(usuario.FlagGerente, FlagGerente);
            Assert.AreEqual(usuario.FlagGerenteFinanceiro, FlagGerenteFinanceiro);
            Assert.AreEqual(usuario.Gerente, Gerente);
            Assert.AreEqual(usuario.GerenteFinanceiro, GerenteFinanceiro);
            Assert.AreEqual(usuario.GerenteFinanceiroId, GerenteFinanceiroId);
            Assert.AreEqual(usuario.GerenteId, GerenteId);
            Assert.AreEqual(usuario.Id, Id);
            Assert.AreEqual(usuario.Nome, Nome);
            Assert.AreEqual(usuario.Senha, Senha);
            Assert.AreEqual(usuario.Sobrenome, Sobrenome);
        }
    }
}
