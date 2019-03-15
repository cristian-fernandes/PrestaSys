using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unisul.PrestaSys.Entidades.PdfGeneration;

namespace Unisul.PrestaSys.Tests.Entidades.PdfGeneration
{
    [TestClass]
    public class JsReportSettingsTests
    {
        private const string Uri = "http://jsreport/";
        private const string UsernameEmail = "cristian@test.br";
        private const string UsernamePassword = "abacate";

        [TestMethod]
        public void JsReportSettingsPropertiesShouldBeSetAndRetrievedCorrectly()
        {
            var settings = new JsReportSettings();

            settings.Uri = Uri;
            settings.UsernameEmail = UsernameEmail;
            settings.UsernamePassword = UsernamePassword;


            Assert.AreEqual(settings.Uri, Uri);
            Assert.AreEqual(settings.UsernameEmail, UsernameEmail);
            Assert.AreEqual(settings.UsernamePassword, UsernamePassword);
        }
    }
}
