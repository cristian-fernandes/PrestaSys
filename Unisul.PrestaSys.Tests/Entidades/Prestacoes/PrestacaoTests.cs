using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Tests.Entidades.Prestacoes
{
    [TestClass]
    public class PrestacaoTests
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
        private static readonly byte[] ImagemComprovante = new byte[0];
        private static readonly PrestacaoStatus Status = new PrestacaoStatus();
        private static readonly PrestacaoTipo Tipo = new PrestacaoTipo();
        private readonly DateTime _data = DateTime.MinValue;

        [TestMethod]
        public void PrestacaoPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var prestacao = new Prestacao
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
                Justificativa = Justificativa,
                JustificativaAprovacao = JustificativaAprovacao,
                JustificativaAprovacaoFinanceira = JustificativaAprovacaoFinanceira,
                Status = Status,
                StatusId = StatusId,
                Tipo = Tipo,
                TipoId = TipoId,
                Titulo = Titulo,
                Valor = Valor
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
        }
    }
}
