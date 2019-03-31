using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Unisul.PrestaSys.Comum;
using Unisul.PrestaSys.Dominio.Servicos.Prestacoes.PrestacaoStatusActions;
using Unisul.PrestaSys.Entidades.Notificacoes;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Dominio.Servicos.Email
{
    public interface IEmailService
    {
        bool EnviarEmail(Prestacao prestacao, PrestacaoStatuses statusAtual, string emailTo);
    }

    public class EmailService : IEmailService
    {
        private const string Template = @"<h1>PrestaSys - Presta&ccedil;&atilde;o de Contas</h1>
                    <p> <b> Presta&ccedil;&atilde;o: </b> {{TITULO}} </p>
                    <p> <b> Status: </b> {{STATUS}} </p>
                    <p> <i> {{FRASE_FINAL}} </i> </p>";

        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _environment;
        private readonly IPrestacaoStatusActionsFactory _prestacaoStatusActionsFactory;

        public EmailService(IOptions<EmailSettings> emailSettings, IHostingEnvironment environment,
            IPrestacaoStatusActionsFactory prestacaoStatusActionsFactory)
        {
            _emailSettings = emailSettings.Value;
            _environment = environment;
            _prestacaoStatusActionsFactory = prestacaoStatusActionsFactory;
        }

        public bool EnviarEmail(Prestacao prestacao, PrestacaoStatuses statusAtual, string emailTo)
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

        private string GetEmailBody(Prestacao prestacao, PrestacaoStatuses statusAtual)
        {
            var text = Template.Replace("{{TITULO}}", prestacao.Titulo);

            return _prestacaoStatusActionsFactory.CreateObject(statusAtual).GetEmailBody(text);
        }
    }
}
