using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Helpers;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Tests.Dominio.Prestacoes
{
    [TestClass]
    public class PrestacaoServiceTests
    {
        [TestMethod]
        public void PrestacaoCreateShouldBeCalledCorrectly()
        {
            // Arrange
            const int prestacaoToBeGet = 7;
            var prestacao = new Prestacao {Titulo = "Cristian"};


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.Create(prestacao) == prestacaoToBeGet);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.Create(prestacao);

            // Assert
            result.IsSameOrEqualTo(prestacaoToBeGet);
        }

        [TestMethod]
        public void PrestacaoExistsShouldBeCalledCorrectly()
        {
            // Arrange
            const int prestacaoToBeGet = 7;


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.Exists(prestacaoToBeGet));

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.Exists(prestacaoToBeGet);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PrestacaoGetAllShouldBeCalledCorrectly()
        {
            // Arrange

            var prestacoes = new List<Prestacao>
            {
                new Prestacao {Titulo = "Fernandes", Justificativa = "Cris"},
                new Prestacao {Titulo = "Teste", Justificativa = "Ale"}
            };

            var prestacoesList = prestacoes.AsQueryable();

            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetAll() == prestacoesList);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(prestacoesList);
        }

        [TestMethod]
        public void PrestacaoGetByIdShouldBeCalledCorrectly()
        {
            // Arrange

            var prestacao = new Prestacao();
            const int id = 7;


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetById(id) == prestacao);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetById(id);

            // Assert
            result.IsSameOrEqualTo(prestacao);
        }

        [TestMethod]
        public void PrestacaoIDeletePrestacaoShouldBeCalledCorrectly()
        {
            // Arrange
            const int id = 7;
            const int expectedResult = 1;


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.Delete(id) == expectedResult);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.Delete(id);

            // Assert
            Mock.Get(prestacaoRepository).Verify(m => m.Delete(id), Times.Once);
            result.IsSameOrEqualTo(expectedResult);
        }

        [TestMethod]
        public void PrestacaoIUpdatePrestacaoShouldBeCalledCorrectly()
        {
            // Arrange
            const string titulo = "dasdsad";
            var prestacao = new Prestacao {Titulo = titulo};

            const int id = 7;


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.Update(prestacao) == id);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            prestacaoService.Update(prestacao);

            // Assert
            Mock.Get(prestacaoRepository).Verify(m => m.Update(prestacao), Times.Once);
        }

        [TestMethod]
        public void PrestacaoIAprovarPrestacaoShouldBeCalledCorrectlyWhenInAprovacaoOperacional()
        {
            // Arrange
            const string titulo = "Titulo";
            const string email = "test@test.com";
            const int id = 1;
            const PrestacaoStatuses tipoAprovacao = PrestacaoStatuses.EmAprovacaoOperacional;
            const string justificativa = "Teste Justificativa";

            var prestacao = new Prestacao
            {
                Id = id,
                Titulo = titulo,
                EmitenteId = 1,
                AprovadorId = 2,
                AprovadorFinanceiroId = 3,
                StatusId = (int)PrestacaoStatuses.EmAprovacaoOperacional
            };


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetById(id) == prestacao);
            var usuarioService = Mock.Of<IUsuarioService>(m => m.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId) == email);
            var emailHelper = Mock.Of<IEmailHelper>(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email));

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, emailHelper, usuarioService);

            // Act
            prestacaoService.AprovarPrestacao(prestacao.Id, justificativa, tipoAprovacao);

            // Assert

            Mock.Get(prestacaoRepository).Verify(m => m.Update(prestacao), Times.Once);
            Mock.Get(usuarioService).Verify(m => m.GetUsuarioEmailById(prestacao.AprovadorFinanceiroId), Times.Once);
            Mock.Get(emailHelper).Verify(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email), Times.Once);
            prestacao.StatusId.Should().Be((int) PrestacaoStatuses.EmAprovacaoFinanceira);
        }

        [TestMethod]
        public void PrestacaoIAprovarPrestacaoShouldBeCalledCorrectlyWhenInAprovacaoFinanceira()
        {
            // Arrange
            const string titulo = "Titulo";
            const string email = "test@test.com";
            const int id = 1;
            const PrestacaoStatuses tipoAprovacao = PrestacaoStatuses.EmAprovacaoFinanceira;
            const string justificativa = "Teste Justificativa";

            var prestacao = new Prestacao
            {
                Id = id,
                Titulo = titulo,
                EmitenteId = 1,
                AprovadorId = 2,
                AprovadorFinanceiroId = 3,
                StatusId = (int)PrestacaoStatuses.EmAprovacaoFinanceira
            };


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetById(id) == prestacao);
            var usuarioService = Mock.Of<IUsuarioService>(m => m.GetUsuarioEmailById(prestacao.EmitenteId) == email);
            var emailHelper = Mock.Of<IEmailHelper>(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email));

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, emailHelper, usuarioService);

            // Act
            prestacaoService.AprovarPrestacao(prestacao.Id, justificativa, tipoAprovacao);

            // Assert

            Mock.Get(prestacaoRepository).Verify(m => m.Update(prestacao), Times.Once);
            Mock.Get(usuarioService).Verify(m => m.GetUsuarioEmailById(prestacao.EmitenteId), Times.Once);
            Mock.Get(emailHelper).Verify(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email), Times.Once);
            prestacao.StatusId.Should().Be((int)PrestacaoStatuses.Finalizada);
        }

        [TestMethod]
        public void UsuarioGetAllByEmitenteIdShouldBeCalledCorrectly()
        {
            // Arrange
            const int id = 1;
            var prestacoes = new List<Prestacao>
            {
                new Prestacao {Titulo = "Teste", EmitenteId = 1},
                new Prestacao {Titulo = "Teste2", EmitenteId = 1},
                new Prestacao {Titulo = "Teste3", EmitenteId = 2},
            };

            var prestacoesList = prestacoes.AsQueryable();

            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetAll() == prestacoesList);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAllByEmitenteId(id);

            // Assert
            result.Should().BeEquivalentTo(prestacoesList.Where(x => x.EmitenteId == id));
        }

        [TestMethod]
        public void PrestacaoGetAllPrestacoesTiposShouldBeCalledCorrectly()
        {
            // Arrange

            var prestacoesTipos = new List<PrestacaoTipo>
            {
                new PrestacaoTipo {Id = 1, Tipo = "aaa"},
                new PrestacaoTipo {Id = 2, Tipo = "BBB"}
            };

            var prestacoesTiposList = prestacoesTipos.AsQueryable();

            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetAllPrestacaoTipos() == prestacoesTiposList);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAllPrestacaoTipos();

            // Assert
            result.Should().BeEquivalentTo(prestacoesTiposList);
        }

        [TestMethod]
        public void PrestacaoIRejeitarPrestacaoShouldBeCalledCorrectlyWhenInAprovacaoOperacional()
        {
            // Arrange
            const string titulo = "Titulo";
            const string email = "test@test.com";
            const int id = 1;
            const PrestacaoStatuses tipoAprovacao = PrestacaoStatuses.EmAprovacaoOperacional;
            const string justificativa = "Teste Justificativa";

            var prestacao = new Prestacao
            {
                Id = id,
                Titulo = titulo,
                EmitenteId = 1,
                AprovadorId = 2,
                AprovadorFinanceiroId = 3,
                StatusId = (int)PrestacaoStatuses.EmAprovacaoOperacional
            };


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetById(id) == prestacao);
            var usuarioService = Mock.Of<IUsuarioService>(m => m.GetUsuarioEmailById(prestacao.EmitenteId) == email);
            var emailHelper = Mock.Of<IEmailHelper>(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email));

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, emailHelper, usuarioService);

            // Act
            prestacaoService.RejeitarPrestacao(prestacao.Id, justificativa, tipoAprovacao);

            // Assert

            Mock.Get(prestacaoRepository).Verify(m => m.Update(prestacao), Times.Once);
            Mock.Get(usuarioService).Verify(m => m.GetUsuarioEmailById(prestacao.EmitenteId), Times.Once);
            Mock.Get(emailHelper).Verify(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email), Times.Once);
            prestacao.StatusId.Should().Be((int)PrestacaoStatuses.Rejeitada);
        }

        [TestMethod]
        public void PrestacaoIRejeitarPrestacaoShouldBeCalledCorrectlyWhenInAprovacaoFinanceira()
        {
            // Arrange
            const string titulo = "Titulo";
            const string email = "test@test.com";
            const int id = 1;
            const PrestacaoStatuses tipoAprovacao = PrestacaoStatuses.EmAprovacaoFinanceira;
            const string justificativa = "Teste Justificativa";

            var prestacao = new Prestacao
            {
                Id = id,
                Titulo = titulo,
                EmitenteId = 1,
                AprovadorId = 2,
                AprovadorFinanceiroId = 3,
                StatusId = (int)PrestacaoStatuses.EmAprovacaoFinanceira
            };


            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetById(id) == prestacao);
            var usuarioService = Mock.Of<IUsuarioService>(m => m.GetUsuarioEmailById(prestacao.EmitenteId) == email);
            var emailHelper = Mock.Of<IEmailHelper>(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email));

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, emailHelper, usuarioService);

            // Act
            prestacaoService.RejeitarPrestacao(prestacao.Id, justificativa, tipoAprovacao);

            // Assert

            Mock.Get(prestacaoRepository).Verify(m => m.Update(prestacao), Times.Once);
            Mock.Get(usuarioService).Verify(m => m.GetUsuarioEmailById(prestacao.EmitenteId), Times.Once);
            Mock.Get(emailHelper).Verify(m => m.EnviarEmail(prestacao, (PrestacaoStatuses)prestacao.StatusId, email), Times.Once);
            prestacao.StatusId.Should().Be((int)PrestacaoStatuses.Rejeitada);
        }

        [TestMethod]
        public void PrestacaoGetAllParaAprovacaoShouldBeCalledCorrectly()
        {
            // Arrange
            const int aprovadorId = 1;
            var prestacoes = new List<Prestacao>
            {
                new Prestacao
                {
                    Titulo = "Teste", AprovadorId = aprovadorId, StatusId = (int)PrestacaoStatuses.EmAprovacaoOperacional
                },
                new Prestacao
                {
                    Titulo = "Teste2", AprovadorFinanceiroId = 9, StatusId = (int)PrestacaoStatuses.EmAprovacaoFinanceira
                },
                new Prestacao
                {
                    Titulo = "aaaa", EmitenteId = 3, StatusId = (int)PrestacaoStatuses.Rejeitada
                },
                new Prestacao
                {
                    Titulo = "645485", EmitenteId = 4, StatusId = (int)PrestacaoStatuses.Finalizada
                }
            };

            var prestacoesList = prestacoes.AsQueryable();

            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetAll() == prestacoesList);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAllParaAprovacao(aprovadorId, PrestacaoStatuses.EmAprovacaoOperacional);

            // Assert
            result.Should().BeEquivalentTo(prestacoesList.Where(x => x.AprovadorId == aprovadorId));
        }

        [TestMethod]
        public void PrestacaoGetAllParaAprovacaoFinanceiraShouldBeCalledCorrectly()
        {
            // Arrange
            const int aprovadorId = 1;
            var prestacoes = new List<Prestacao>
            {
                new Prestacao
                {
                    Titulo = "Teste", AprovadorId = 5, StatusId = (int)PrestacaoStatuses.EmAprovacaoOperacional
                },
                new Prestacao
                {
                    Titulo = "Teste2", AprovadorFinanceiroId = aprovadorId, StatusId = (int)PrestacaoStatuses.EmAprovacaoFinanceira
                },
                new Prestacao
                {
                    Titulo = "aaaa", EmitenteId = 3, StatusId = (int)PrestacaoStatuses.Rejeitada
                },
                new Prestacao
                {
                    Titulo = "645485", EmitenteId = 4, StatusId = (int)PrestacaoStatuses.Finalizada
                }
            };

            var prestacoesList = prestacoes.AsQueryable();

            var prestacaoRepository = Mock.Of<IPrestacaoRepository>(m => m.GetAll() == prestacoesList);

            var prestacaoService =
                new PrestacaoService(prestacaoRepository, Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAllParaAprovacao(aprovadorId, PrestacaoStatuses.EmAprovacaoFinanceira);

            // Assert
            result.Should().BeEquivalentTo(prestacoesList.Where(x => x.AprovadorFinanceiroId == aprovadorId));
        }

        [TestMethod]
        public void PrestacaoGetEmailToShouldReturnEmptyString()
        {

            var prestacaoService =
                new PrestacaoService(Mock.Of<IPrestacaoRepository>(), Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetEmailTo(new Prestacao(), (PrestacaoStatuses)10);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void PrestacaoGetAllParaAprovacaoReturnEmptyList()
        {
            // Arrange
            var prestacaoService =
                new PrestacaoService(Mock.Of<IPrestacaoRepository>(), Mock.Of<IEmailHelper>(), Mock.Of<IUsuarioService>());

            // Act
            var result = prestacaoService.GetAllParaAprovacao(It.IsAny<int>(), PrestacaoStatuses.Finalizada);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
