using System.Linq;
using EntityFrameworkCoreMock;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Repositorio;
using Unisul.PrestaSys.Repositorio.Usuarios;

namespace Unisul.PrestaSys.Tests.Repositorio.Usuarios
{
    [TestClass]
    public class UsuarioRepositoryTests
    {
        private DbContextOptions<PrestaSysDbContext> DummyOptions { get; } =
            new DbContextOptionsBuilder<PrestaSysDbContext>().Options;

        [TestMethod]
        public void ShouldCallCreateUsuarioFromPrestaSysDbContext()
        {
            // Arrange
            const int expectedResult = 1;
            var usuarioEntity = new Usuario();
            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            dbContextMock.Setup(s => s.Add(usuarioEntity)).Returns(It.IsAny<EntityEntry<Usuario>>());
            dbContextMock.Setup(s => s.SaveChanges()).Returns(expectedResult);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.Create(usuarioEntity);

            // Assert
            dbContextMock.Verify(m => m.Add(usuarioEntity), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ShouldCallDeleteUsuarioFromPrestaSysDbContext()
        {
            // Arrange
            const int usuarioToBeDeleted = 7;
            const int expectedResult = 1;

            var usuarioEntity = new Usuario
            {
                Id = usuarioToBeDeleted
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            dbContextMock.Setup(s => s.Usuario.Find(usuarioToBeDeleted)).Returns(usuarioEntity);
            dbContextMock.Setup(s => s.Usuario.Remove(usuarioEntity)).Returns(It.IsAny<EntityEntry<Usuario>>);
            dbContextMock.Setup(s => s.SaveChanges()).Returns(expectedResult);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.Delete(usuarioToBeDeleted);

            // Assert
            dbContextMock.Verify(m => m.Usuario.Find(usuarioToBeDeleted), Times.Once());
            dbContextMock.Verify(m => m.Usuario.Remove(usuarioEntity), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ShouldCallExistsUsuarioFromPrestaSysDbContextAndTheResultShouldBeFalse()
        {
            // Arrange
            const int usuarioToBeFind = 7;

            var usuarios = new[]
            {
                new Usuario {Nome = "BBB", Id = 2},
                new Usuario {Nome = "ZZZ", Id = 1},
                new Usuario {Nome = "AAA", Id = 8}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var usuarioDbSetMock = dbContextMock.CreateDbSetMock(x => x.Usuario, usuarios);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.Exists(usuarioToBeFind);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCallExistsUsuarioFromPrestaSysDbContextAndTheResultShouldBeTrue()
        {
            // Arrange
            const int usuarioToBeFind = 7;

            var usuarios = new[]
            {
                new Usuario {Nome = "BBB", Id = 2},
                new Usuario {Nome = "ZZZ", Id = 1},
                new Usuario {Nome = "AAA", Id = 7}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var usuarioDbSetMock = dbContextMock.CreateDbSetMock(x => x.Usuario, usuarios);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.Exists(usuarioToBeFind);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCallGetAllUsuarioFromPrestaSysDbContext()
        {
            // Arrange
            var usuarios = new[]
            {
                new Usuario {Nome = "BBB", Id = 2},
                new Usuario {Nome = "ZZZ", Id = 1},
                new Usuario {Nome = "AAA", Id = 8},
                new Usuario {Nome = "AAA", Id = 15}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var usuarioDbSetMock = dbContextMock.CreateDbSetMock(x => x.Usuario, usuarios);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.GetAll();

            // Assert
            result.Should().OnlyHaveUniqueItems();
            result.Should().NotContainNulls();
            result.Should().BeEquivalentTo(usuarios.ToList(), options => options.ComparingEnumsByValue());
        }

        [TestMethod]
        public void ShouldCallGetByIdFromPrestaSysDbContextAndReturnTheCorrectEntity()
        {
            // Arrange
            const int usuarioToBeGet = 7;

            var usuarios = new[]
            {
                new Usuario {Nome = "BBB", Id = 2},
                new Usuario {Nome = "ZZZ", Id = 1},
                new Usuario {Nome = "AAA", Id = 7},
                new Usuario {Nome = "AAA", Id = 15}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var usuarioDbSetMock = dbContextMock.CreateDbSetMock(x => x.Usuario, usuarios);

            var usuarioRepository = new UsuarioRepository(dbContextMock.Object);

            // Act
            var result = usuarioRepository.GetById(usuarioToBeGet);

            // Assert
            result.IsSameOrEqualTo(usuarios[2]);
        }
    }
}
