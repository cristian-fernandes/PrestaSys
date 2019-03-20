using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    }
}
