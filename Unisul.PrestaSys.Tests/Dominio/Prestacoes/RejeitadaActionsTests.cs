using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Tests.Dominio.Prestacoes
{
    [TestClass]
    public class RejeitadaActionsTests
    {
        [TestMethod]
        public void AprovarPrestacaoShouldThrowNotSupportedException()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste"};
            const string justificativa = "Teste de Justificativa";

            var rejeitadaActions =
                new RejeitadaActions(prestacaoRepository, usuarioService);

            // Act & Assert
            Assert.ThrowsException<NotSupportedException>(
                () => rejeitadaActions.AprovarPrestacao(prestacao, justificativa)); 
        }

        [TestMethod]
        public void RejeitarPrestacaoShouldThrowNotSupportedException()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste"};
            const string justificativa = "Teste de Justificativa";

            var rejeitadaActions =
                new RejeitadaActions(prestacaoRepository, usuarioService);

            // Act & Assert
            Assert.ThrowsException<NotSupportedException>(
                () => rejeitadaActions.RejeitarPrestacao(prestacao, justificativa)); 
        }

        [TestMethod]
        public void GetAllParaAprovacaoShouldThrowNotSupportedException()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var rejeitadaActions =
                new RejeitadaActions(prestacaoRepository, usuarioService);

            // Act & Assert
            Assert.ThrowsException<NotSupportedException>(
                () => rejeitadaActions.GetAllParaAprovacao(1)); 
        }

        [TestMethod]
        public void GetEmailToShouldReturnEmitentId()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste", EmitenteId = 2};
            var expectedUsuario = "test@test.com";

            Mock.Get(usuarioService).Setup(x => x.GetUsuarioEmailById(prestacao.EmitenteId)).Returns(expectedUsuario);

            var rejeitadaActions =
                new RejeitadaActions(prestacaoRepository, usuarioService);

            // Act
            var returnedUsuario = rejeitadaActions.GetEmailTo(prestacao);

            // Assert
            returnedUsuario.Should().Be(expectedUsuario);
        }
    }
}
