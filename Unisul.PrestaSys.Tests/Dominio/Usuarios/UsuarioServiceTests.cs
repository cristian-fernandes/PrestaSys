using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Repositorio.Usuarios;

namespace Unisul.PrestaSys.Tests.Dominio.Usuarios
{
    [TestClass]
    public class UsuarioServiceTests
    {
        [TestMethod]
        public void UsuarioCreateShouldBeCalledCorrectly()
        {
            // Arrange
            const int usuarioToBeGet = 7;
            var usuario = new Usuario {Nome = "Cristian"};


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.Create(usuario) == usuarioToBeGet);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.Create(usuario);

            // Assert
            result.IsSameOrEqualTo(usuarioToBeGet);
        }

        [TestMethod]
        public void UsuarioExistsShouldBeCalledCorrectly()
        {
            // Arrange
            const int usuarioToBeGet = 7;


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.Exists(usuarioToBeGet));

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.Exists(usuarioToBeGet);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UsuarioGetAllGerentesFinanceirosShouldBeCalledCorrectly()
        {
            // Arrange

            var usuarios = new List<Usuario>
            {
                new Usuario {Sobrenome = "Fernandes", Nome = "Cris", FlagGerenteFinanceiro = true},
                new Usuario {Sobrenome = "Fernandessss", Nome = "Cristian", FlagGerenteFinanceiro = false},
                new Usuario {Sobrenome = "Teste", Nome = "Ale", FlagGerenteFinanceiro = false}
            };

            var usuariosList = usuarios.AsQueryable();

            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetAll() == usuariosList);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetAllGerentesFinanceiros();

            // Assert
            result.Should().BeEquivalentTo(usuariosList.Where(x => x.FlagGerenteFinanceiro));
        }

        [TestMethod]
        public void UsuarioGetAllShouldBeCalledCorrectly()
        {
            // Arrange

            var usuarios = new List<Usuario>
            {
                new Usuario {Sobrenome = "Fernandes", Nome = "Cris"},
                new Usuario {Sobrenome = "Teste", Nome = "Ale"}
            };

            var usuariosList = usuarios.AsQueryable();

            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetAll() == usuariosList);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(usuariosList);
        }

        [TestMethod]
        public void UsuarioGetByIdShouldBeCalledCorrectly()
        {
            // Arrange

            var usuario = new Usuario();
            const int id = 7;


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetById(id) == usuario);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetById(id);

            // Assert
            result.IsSameOrEqualTo(usuario);
        }

        [TestMethod]
        public void UsuarioGetGerentesAllShouldBeCalledCorrectly()
        {
            // Arrange

            var usuarios = new List<Usuario>
            {
                new Usuario {Sobrenome = "Fernandes", Nome = "Cris", FlagGerente = true},
                new Usuario {Sobrenome = "Fernandessss", Nome = "Cristian", FlagGerente = false},
                new Usuario {Sobrenome = "Teste", Nome = "Ale", FlagGerente = false}
            };

            var usuariosList = usuarios.AsQueryable();

            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetAll() == usuariosList);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetAllGerentes();

            // Assert
            result.Should().BeEquivalentTo(usuariosList.Where(x => x.FlagGerente));
        }

        [TestMethod]
        public void UsuarioGetUsuarioByEmailAndSenhaShouldBeCalledCorrectly()
        {
            // Arrange
            const string emailToBeGet = "a@a.com";
            const string senhaToBeGet = "abacate";
            var usuarios = new List<Usuario>
            {
                new Usuario {Sobrenome = "Fernandes", Nome = "Cris", Email = emailToBeGet, Senha = senhaToBeGet},
                new Usuario {Sobrenome = "Fernandessss", Nome = "Cristian", Email = "c@a.com", Senha = "asas"},
                new Usuario {Sobrenome = "Teste", Nome = "Ale", Email = "c@a.com", Senha = "dsdsfd"}
            };

            var usuariosList = usuarios.AsQueryable();

            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetAll() == usuariosList);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetUsuarioByEmailAndSenha(emailToBeGet, senhaToBeGet);

            // Assert
            result.IsSameOrEqualTo(usuariosList.Where(x => x.Email == emailToBeGet && x.Senha == senhaToBeGet));
        }

        [TestMethod]
        public void UsuarioGetUsuarioByEmailShouldBeCalledCorrectly()
        {
            // Arrange
            const string emailToBeGet = "a@a.com";
            var usuarios = new List<Usuario>
            {
                new Usuario {Sobrenome = "Fernandes", Nome = "Cris", Email = emailToBeGet},
                new Usuario {Sobrenome = "Fernandessss", Nome = "Cristian", Email = "c@a.com"},
                new Usuario {Sobrenome = "Teste", Nome = "Ale", Email = "c@a.com"}
            };

            var usuariosList = usuarios.AsQueryable();

            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetAll() == usuariosList);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetUsuarioByEmail(emailToBeGet);

            // Assert
            result.IsSameOrEqualTo(usuariosList.Where(x => x.Email == emailToBeGet));
        }

        [TestMethod]
        public void UsuarioGetUsuarioEmailByIdShouldBeCalledCorrectly()
        {
            // Arrange
            const string email = "a@a.com";
            var usuario = new Usuario {Email = email};
            const int id = 7;


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.GetById(id) == usuario);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.GetUsuarioEmailById(id);

            // Assert
            result.IsSameOrEqualTo(email);
        }

        [TestMethod]
        public void UsuarioIDeleteUsuarioShouldBeCalledCorrectly()
        {
            // Arrange
            const int id = 7;
            const int expectedResult = 1;


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.Delete(id) == expectedResult);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            var result = usuarioService.Delete(id);

            // Assert
            Mock.Get(usuarioRepository).Verify(m => m.Delete(id), Times.Once);
            result.IsSameOrEqualTo(expectedResult);
        }

        [TestMethod]
        public void UsuarioIUpdateUsuarioShouldBeCalledCorrectly()
        {
            // Arrange
            const string email = "a@a.com";
            var usuario = new Usuario {Email = email};

            const int id = 7;


            var usuarioRepository = Mock.Of<IUsuarioRepository>(m => m.Update(usuario) == id);

            var usuarioService = new UsuarioService(usuarioRepository);

            // Act
            usuarioService.Update(usuario);

            // Assert
            Mock.Get(usuarioRepository).Verify(m => m.Update(usuario), Times.Once);
        }
    }
}
