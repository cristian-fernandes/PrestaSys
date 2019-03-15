using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Tests.Entidades.Prestacoes
{
    [TestClass]
    public class PrestacaoTests
    {
        private const int AprovadorFinanceiroId = 1;
        private const int AprovadorId = 1;
        private const int EmitenteId = 1;
        private const int Id = 1;
        private const string Justificativa = "Cristian";
        private const string JustificativaAprovacao = "abacate";
        private const string JustificativaAprovacaoFinanceira = "Fernandes";
        private const int StatusId = 1;
        private const int TipoId = 1;
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
            var prestacao = new Prestacao();

            prestacao.Aprovador = Aprovador;
            prestacao.AprovadorFinanceiro = AprovadorFinanceiro;
            prestacao.AprovadorFinanceiroId = AprovadorFinanceiroId;
            prestacao.AprovadorId = AprovadorId;
            prestacao.Data = _data;
            prestacao.Emitente = Emitente;
            prestacao.EmitenteId = EmitenteId;
            prestacao.Id = Id;
            prestacao.ImagemComprovante = ImagemComprovante;
            prestacao.Justificativa = Justificativa;
            prestacao.JustificativaAprovacao = JustificativaAprovacao;
            prestacao.JustificativaAprovacaoFinanceira = JustificativaAprovacaoFinanceira;
            prestacao.Status = Status;
            prestacao.StatusId = StatusId;
            prestacao.Tipo = Tipo;
            prestacao.TipoId = TipoId;
            prestacao.Titulo = Titulo;
            prestacao.Valor = Valor;

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
