using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Entidades.Notificacoes;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Helpers
{
    public interface IEmailHelper
    {
        bool EnviarEmail(Prestacao prestacao, PrestacaoStatusEnum statusAtual, string emailTo);
    }

    public class EmailHelper : IEmailHelper
    {
        public EmailHelper(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        private EmailSettings _emailSettings { get; set; }

        public bool EnviarEmail(Prestacao prestacao, PrestacaoStatusEnum statusAtual, string emailTo)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(_emailSettings.FromEmail, "PrestaSys")
                };

                mail.To.Add(new MailAddress(emailTo));
                mail.To.Clear();
                mail.To.Add(new MailAddress("cristian.fernandes@eldorado.org.br"));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));
                mail.Subject = "PrestaSys - Prestação de Contas - " + prestacao.Titulo;
                mail.Body = GetEmailBody(prestacao, statusAtual);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (var smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials =
                        new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static string GetEmailBody(Prestacao prestacao, PrestacaoStatusEnum statusAtual)
        {
            var text = GetMessageBodyText();
            text = text.Replace("{{TITULO}}", prestacao.Titulo);

            switch (statusAtual)
            {
                case PrestacaoStatusEnum.EmAprovacaoOperacional:
                    text = text.Replace("{{STATUS}}", "Aguardando Aprova&ccedil;&atilde;o Operacional");
                    text = text.Replace("{{FRASE_FINAL}}",
                        "Favor verificar a sua lista de presta&ccedil;&otilde;es pendentes de aprova&ccedil;&atilde;o.");
                    break;
                case PrestacaoStatusEnum.EmAprovacaoFinanceira:
                    text = text.Replace("{{STATUS}}", "Aguardando Aprova&ccedil;&atilde;o Financeira");
                    text = text.Replace("{{FRASE_FINAL}}",
                        "Favor verificar a sua lista de presta&ccedil;&otilde;es pendentes de aprova&ccedil;&atilde;o financeira.");
                    break;
                case PrestacaoStatusEnum.Rejeitada:
                    text = text.Replace("{{STATUS}}", "Rejeitada");
                    text = text.Replace("{{FRASE_FINAL}}",
                        "Favor verificar a sua lista de presta&ccedil;&otilde;es criadas.");
                    break;
                case PrestacaoStatusEnum.Finalizada:
                    text = text.Replace("{{STATUS}}", "Finalizada");
                    text = text.Replace("{{FRASE_FINAL}}", "Agradecemos o uso do PrestaSys");
                    break;
            }

            return text;
        }

        private static string GetMessageBodyText()
        {
            return @"<h2>PrestaSys - Presta&ccedil;&atilde;o de Contas</h2>
                    <p> Presta&ccedil;&atilde;o: {{TITULO}} </p>
                    <p> Status: {{STATUS}} </p>
                    <p> {{FRASE_FINAL}} </p>";
        }
    }
}
