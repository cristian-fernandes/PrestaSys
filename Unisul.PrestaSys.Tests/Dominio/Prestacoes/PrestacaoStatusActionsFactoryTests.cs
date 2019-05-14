using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Tests.Dominio.Prestacoes
{
    [TestClass]
    public class PrestacaoStatusActionsFactoryTests
    {
        [TestMethod]
        public void CreateShouldBeCalledForEmAprovacaoOperacional()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacaoStatusActionsFactory =
                new PrestacaoStatusActionsFactory(prestacaoRepository, usuarioService);

            // Act
            var result = prestacaoStatusActionsFactory.CreateObject(PrestacaoStatuses.EmAprovacaoOperacional);

            // Assert
            result.Should().BeOfType<AprovacaoOperacionalActions>();
        }

        [TestMethod]
        public void CreateShouldBeCalledForEmAprovacaoFinanceira()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacaoStatusActionsFactory =
                new PrestacaoStatusActionsFactory(prestacaoRepository, usuarioService);

            // Act
            var result = prestacaoStatusActionsFactory.CreateObject(PrestacaoStatuses.EmAprovacaoFinanceira);

            // Assert
            result.Should().BeOfType<AprovacaoFinanceiraActions>();
        }

        [TestMethod]
        public void CreateShouldBeCalledForFinalizada()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacaoStatusActionsFactory =
                new PrestacaoStatusActionsFactory(prestacaoRepository, usuarioService);

            // Act
            var result = prestacaoStatusActionsFactory.CreateObject(PrestacaoStatuses.Finalizada);

            // Assert
            result.Should().BeOfType<FinalizadaActions>();
        }

        [TestMethod]
        public void CreateShouldBeCalledForRejeitada()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacaoStatusActionsFactory =
                new PrestacaoStatusActionsFactory(prestacaoRepository, usuarioService);

            // Act
            var result = prestacaoStatusActionsFactory.CreateObject(PrestacaoStatuses.Rejeitada);

            // Assert
            result.Should().BeOfType<RejeitadaActions>();
        }      
    }
}
