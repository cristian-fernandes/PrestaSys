using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Tests.Dominio.Prestacoes
{
    [TestClass]
    public class AprovacaoFinanceiraActionsTests
    {
        [TestMethod]
        public void AprovarPrestacaoShouldBeCalledCorrectly()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste"};
            const string justificativa = "Teste de Justificativa";

            var aprovacaoFinanceiraActions =
                new AprovacaoFinanceiraActions(prestacaoRepository, usuarioService);

            // Act
            aprovacaoFinanceiraActions.AprovarPrestacao(prestacao, justificativa);

            // Assert
            prestacao.StatusId.Should().Be((int)PrestacaoStatuses.Finalizada);
            prestacao.JustificativaAprovacaoFinanceira.Should().Be(justificativa);
        }

        [TestMethod]
        public void RejeitarPrestacaoShouldBeCalledCorrectly()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste"};
            const string justificativa = "Teste de Justificativa";

            var aprovacaoFinanceiraActions =
                new AprovacaoFinanceiraActions(prestacaoRepository, usuarioService);

            // Act
            aprovacaoFinanceiraActions.RejeitarPrestacao(prestacao, justificativa);

            // Assert
            prestacao.StatusId.Should().Be((int)PrestacaoStatuses.Rejeitada);
            prestacao.JustificativaAprovacaoFinanceira.Should().Be(justificativa);
        }

        [TestMethod]
        public void GetEmailToShouldReturnAprovadorFinanceiroId()
        {
            // Arrange
            var prestacaoRepository = Mock.Of<IPrestacaoRepository>();
            var usuarioService = Mock.Of<IUsuarioService>();

            var prestacao = new Prestacao {Id = 1, Titulo = "Teste", AprovadorFinanceiroId = 2};
            var expectedUsuario = "test@test.com";

            Mock.Get(usuarioService).Setup(x => x.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId)).Returns(expectedUsuario);

            var rejeitadaActions =
                new AprovacaoFinanceiraActions(prestacaoRepository, usuarioService);

            // Act
            var returnedUsuario = rejeitadaActions.GetEmailTo(prestacao);

            // Assert
            returnedUsuario.Should().Be(expectedUsuario);
        }
    }
}
