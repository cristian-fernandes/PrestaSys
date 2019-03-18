using System;

using System.Linq;
using EntityFrameworkCoreMock;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Repositorio;
using Unisul.PrestaSys.Repositorio.Prestacoes;

namespace Unisul.PrestaSys.Tests.Repositorio.Prestacoes
{
    [TestClass]
    public class PrestacaoRepositoryTests
    {
        private DbContextOptions<PrestaSysDbContext> DummyOptions { get; } =
            new DbContextOptionsBuilder<PrestaSysDbContext>().Options;

        [TestMethod]
        public void ShouldCallCreatePrestacaoFromPrestaSysDbContext()
        {
            // Arrange
            const int expectedResult = 1;
            var prestacaoEntity = new Prestacao();
            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            dbContextMock.Setup(s => s.Add(prestacaoEntity)).Returns(It.IsAny<EntityEntry<Prestacao>>());
            dbContextMock.Setup(s => s.SaveChanges()).Returns(expectedResult);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.Create(prestacaoEntity);

            // Assert
            dbContextMock.Verify(m => m.Add(prestacaoEntity), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ShouldCallDeletePrestacaoFromPrestaSysDbContext()
        {
            // Arrange
            const int prestacaoToBeDeleted = 7;
            const int expectedResult = 1;

            var prestacaoEntity = new Prestacao
            {
                Id = prestacaoToBeDeleted
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            dbContextMock.Setup(s => s.Prestacao.Find(prestacaoToBeDeleted)).Returns(prestacaoEntity);
            dbContextMock.Setup(s => s.Prestacao.Remove(prestacaoEntity)).Returns(It.IsAny<EntityEntry<Prestacao>>);
            dbContextMock.Setup(s => s.SaveChanges()).Returns(expectedResult);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.Delete(prestacaoToBeDeleted);

            // Assert
            dbContextMock.Verify(m => m.Prestacao.Find(prestacaoToBeDeleted), Times.Once());
            dbContextMock.Verify(m => m.Prestacao.Remove(prestacaoEntity), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ShouldCallExistsPrestacaoFromPrestaSysDbContextAndTheResultShouldBeFalse()
        {
            // Arrange
            const int prestacaoToBeFind = 7;

            var prestacoes = new[]
            {
                new Prestacao {Titulo = "BBB", Id = 2},
                new Prestacao {Titulo = "ZZZ", Id = 1},
                new Prestacao {Titulo = "AAA", Id = 8}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var prestacaoDbSetMock = dbContextMock.CreateDbSetMock(x => x.Prestacao, prestacoes);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.Exists(prestacaoToBeFind);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCallExistsPrestacaoFromPrestaSysDbContextAndTheResultShouldBeTrue()
        {
            // Arrange
            const int prestacaoToBeFind = 7;

            var prestacoes = new[]
            {
                new Prestacao {Titulo = "BBB", Id = 2},
                new Prestacao {Titulo = "ZZZ", Id = 1},
                new Prestacao {Titulo = "AAA", Id = 7}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var prestacaoDbSetMock = dbContextMock.CreateDbSetMock(x => x.Prestacao, prestacoes);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.Exists(prestacaoToBeFind);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCallGetAllPrestacaoFromPrestaSysDbContext()
        {
            // Arrange
            var prestacoes = new[]
            {
                new Prestacao {Titulo = "BBB", Id = 2},
                new Prestacao {Titulo = "ZZZ", Id = 1},
                new Prestacao {Titulo = "AAA", Id = 8},
                new Prestacao {Titulo = "AAA", Id = 15}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var prestacaoDbSetMock = dbContextMock.CreateDbSetMock(x => x.Prestacao, prestacoes);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.GetAll();

            // Assert
            result.Should().OnlyHaveUniqueItems();
            result.Should().NotContainNulls();
            result.Should().BeEquivalentTo(prestacoes.ToList(), options => options.ComparingEnumsByValue());
        }

        [TestMethod]
        public void ShouldCallGetAllPrestacaoTiposFromPrestaSysDbContext()
        {
            // Arrange
            var prestacaoTipos = new[]
            {
                new PrestacaoTipo {Tipo = "BBB", Id = 2},
                new PrestacaoTipo {Tipo = "ZZZ", Id = 1},
                new PrestacaoTipo {Tipo = "AAA", Id = 8},
                new PrestacaoTipo {Tipo = "AAA", Id = 15}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var prestacaoDbSetMock = dbContextMock.CreateDbSetMock(x => x.PrestacaoTipo, prestacaoTipos);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.GetAllPrestacaoTipos();

            // Assert
            result.Should().OnlyHaveUniqueItems();
            result.Should().NotContainNulls();
            result.Should().BeEquivalentTo(prestacaoTipos.ToList(), options => options.ComparingEnumsByValue());
        }

        [TestMethod]
        public void ShouldCallGetByIdFromPrestaSysDbContextAndReturnTheCorrectEntity()
        {
            // Arrange
            const int prestacaoToBeGet = 7;

            var prestacoes = new[]
            {
                new Prestacao {Titulo = "BBB", Id = 2},
                new Prestacao {Titulo = "ZZZ", Id = 1},
                new Prestacao {Titulo = "AAA", Id = 7},
                new Prestacao {Titulo = "AAA", Id = 15}
            };

            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            var prestacaoDbSetMock = dbContextMock.CreateDbSetMock(x => x.Prestacao, prestacoes);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.GetById(prestacaoToBeGet);

            // Assert
            result.IsSameOrEqualTo(prestacoes[2]);
        }

        [TestMethod]
        public void ShouldCallUpdatePrestacaoFromPrestaSysDbContext()
        {
            // Arrange
            const int expectedResult = 1;
            var prestacaoEntity = new Prestacao();
            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);
            dbContextMock.Setup(s => s.Update(prestacaoEntity)).Returns(It.IsAny<EntityEntry<Prestacao>>());
            dbContextMock.Setup(s => s.SaveChanges()).Returns(expectedResult);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            var result = prestacaoRepository.Update(prestacaoEntity);

            // Assert
            dbContextMock.Verify(m => m.Update(prestacaoEntity), Times.Once());
            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CallingUpdatePrestacaoFromPrestaSysDbContextShouldThrowException()
        {
            // Arrange
            var dbContextMock = new DbContextMock<PrestaSysDbContext>(DummyOptions);

            var prestacaoRepository = new PrestacaoRepository(dbContextMock.Object);

            // Act
            prestacaoRepository.Update(null);
        }
    }
}
