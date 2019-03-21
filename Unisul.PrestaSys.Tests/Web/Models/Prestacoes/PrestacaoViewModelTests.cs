using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Prestacoes;

namespace Unisul.PrestaSys.Tests.Web.Models.Prestacoes
{
    [TestClass]
    public class PrestacaoViewModelTests
    {
        private const int AprovadorFinanceiroId = 3;
        private const int AprovadorId = 1;
        private const int EmitenteId = 2;
        private const int Id = 4;
        private const string Justificativa = "Cristian";
        private const string JustificativaAprovacao = "abacate";
        private const string JustificativaAprovacaoFinanceira = "Fernandes";
        private const int StatusId = 5;
        private const int TipoId = 6;
        private const string Titulo = "Titulo";
        private const decimal Valor = 0M;
        private static readonly Usuario Aprovador = new Usuario();
        private static readonly Usuario AprovadorFinanceiro = new Usuario();
        private static readonly Usuario Emitente = new Usuario();
        private static readonly IFormFile ImagemComprovante = new FormFile(Stream.Null, long.MinValue, long.MinValue, "Test", "");
        private static readonly string ImagemComprovanteSrc = string.Empty;
        private static readonly PrestacaoStatus Status = new PrestacaoStatus();
        private static readonly PrestacaoTipo Tipo = new PrestacaoTipo();
        private readonly DateTime _data = DateTime.MinValue;
        private const string ButtonText = "aaa";
        private const string Action = "aaa";
        private static readonly SelectList TipoPrestacaoSelectList = new SelectList(new List<PrestacaoTipo>());

        [TestMethod]
        public void ShouldLockPrestacaoShouldBeFalse()
        {
            var prestacaoViewModel = new PrestacaoViewModel {StatusId = (int) PrestacaoStatuses.EmAprovacaoOperacional};

            prestacaoViewModel.ShouldLockPrestacao.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldLockPrestacaoShouldBeTrue()
        {
            var prestacaoViewModel = new PrestacaoViewModel {StatusId = (int) PrestacaoStatuses.Finalizada};

            prestacaoViewModel.ShouldLockPrestacao.Should().BeTrue();
        }

        [TestMethod]
        public void PrestacaoViewModelPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var prestacao = new PrestacaoViewModel
            {
                Aprovador = Aprovador,
                AprovadorFinanceiro = AprovadorFinanceiro,
                AprovadorFinanceiroId = AprovadorFinanceiroId,
                AprovadorId = AprovadorId,
                Data = _data,
                Emitente = Emitente,
                EmitenteId = EmitenteId,
                Id = Id,
                ImagemComprovante = ImagemComprovante,
                ImagemComprovanteSrc = ImagemComprovanteSrc,
                Justificativa = Justificativa,
                JustificativaAprovacao = JustificativaAprovacao,
                JustificativaAprovacaoFinanceira = JustificativaAprovacaoFinanceira,
                Status = Status,
                StatusId = StatusId,
                Tipo = Tipo,
                TipoId = TipoId,
                Titulo = Titulo,
                Valor = Valor,
                ButtonText = ButtonText,
                Action = Action,
                TipoPrestacaoSelectList = TipoPrestacaoSelectList
            };

            Assert.AreEqual(prestacao.Aprovador, Aprovador);
            Assert.AreEqual(prestacao.AprovadorFinanceiro, AprovadorFinanceiro);
            Assert.AreEqual(prestacao.AprovadorFinanceiroId, AprovadorFinanceiroId);
            Assert.AreEqual(prestacao.AprovadorId, AprovadorId);
            Assert.AreEqual(prestacao.Data, _data);
            Assert.AreEqual(prestacao.Emitente, Emitente);
            Assert.AreEqual(prestacao.EmitenteId, EmitenteId);
            Assert.AreEqual(prestacao.Id, Id);
            Assert.AreEqual(prestacao.ImagemComprovante, ImagemComprovante);
            Assert.AreEqual(prestacao.Justificativa, Justificativa);
            Assert.AreEqual(prestacao.JustificativaAprovacao, JustificativaAprovacao);
            Assert.AreEqual(prestacao.JustificativaAprovacaoFinanceira, JustificativaAprovacaoFinanceira);
            Assert.AreEqual(prestacao.Status, Status);
            Assert.AreEqual(prestacao.StatusId, StatusId);
            Assert.AreEqual(prestacao.Id, Id);
            Assert.AreEqual(prestacao.Tipo, Tipo);
            Assert.AreEqual(prestacao.TipoId, TipoId);
            Assert.AreEqual(prestacao.Titulo, Titulo);
            Assert.AreEqual(prestacao.Valor, Valor);
            Assert.AreEqual(prestacao.ButtonText, ButtonText);
            Assert.AreEqual(prestacao.Action, Action);
            Assert.AreEqual(prestacao.TipoPrestacaoSelectList, TipoPrestacaoSelectList);
        }
    }
}
