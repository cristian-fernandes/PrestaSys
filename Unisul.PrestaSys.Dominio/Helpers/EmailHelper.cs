using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
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
        private readonly EmailSettings _emailSettings;

        private readonly IHostingEnvironment _environment;

        public EmailHelper(IOptions<EmailSettings> emailSettings, IHostingEnvironment environment)
        {
            _emailSettings = emailSettings.Value;
            _environment = environment;
        }

        public bool EnviarEmail(Prestacao prestacao, PrestacaoStatusEnum statusAtual, string emailTo)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(_emailSettings.FromEmail, "PrestaSys")
                };

                mail.To.Add(new MailAddress(emailTo));
                mail.Subject = "PrestaSys - Prestação de Contas - " + prestacao.Titulo;
                mail.Body = GetEmailBody(prestacao, statusAtual);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (var smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials =
                        new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);

                    smtp.EnableSsl = true;

                    if (!_environment.IsDevelopment())
                        smtp.Send(mail);

                    return true;
                }
            }
            catch (Exception)
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
            return @"<h1>PrestaSys - Presta&ccedil;&atilde;o de Contas</h1>
                    <p> <b> Presta&ccedil;&atilde;o: </b> {{TITULO}} </p>
                    <p> <b> Status: </b> {{STATUS}} </p>
                    <p> <i> {{FRASE_FINAL}} </i> </p>";
        }
    }
}
