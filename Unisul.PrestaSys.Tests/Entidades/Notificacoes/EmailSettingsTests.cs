using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.Notificacoes;

namespace Unisul.PrestaSys.Tests.Entidades.Notificacoes
{
    [TestClass]
    public class EmailSettingsTests
    {
        private const string PrimaryDomain = "http://jsreport/";
        private const int PrimaryPort = 587;
        private const string UsernameEmail = "cristian@test.br";
        private const string UsernamePassword = "abacate";
        private const string FromEmail = "cristian@test.br";
        private const string ToEmail = "cristian@test.br";
        private const string CcEmail = "cristian@test.br";

        [TestMethod]
        public void JsReportSettingsPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var settings = new EmailSettings();

            settings.PrimaryDomain = PrimaryDomain;
            settings.PrimaryPort = PrimaryPort;
            settings.UsernameEmail = UsernameEmail;
            settings.UsernamePassword = UsernamePassword;
            settings.FromEmail = FromEmail;
            settings.ToEmail = ToEmail;
            settings.CcEmail = CcEmail;

            Assert.AreEqual(settings.PrimaryDomain, PrimaryDomain);
            Assert.AreEqual(settings.PrimaryPort, PrimaryPort);
            Assert.AreEqual(settings.UsernameEmail, UsernameEmail);
            Assert.AreEqual(settings.UsernamePassword, UsernamePassword);
            Assert.AreEqual(settings.FromEmail, FromEmail);
            Assert.AreEqual(settings.ToEmail, ToEmail);
            Assert.AreEqual(settings.CcEmail, CcEmail);
        }
    }
}
