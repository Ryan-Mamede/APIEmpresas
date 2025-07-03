using ApiEmpresas.Messages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Messages.Services
{
    /// <summary>
    /// Classe para serviço de envio de email.
    /// </summary>
    public class MailService
    {
        //Atributo
        private readonly MailSettings _mailSettings;

        //Construtor para injeção de dependência
        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public void SendMail(string to, string subject, string body)
        {
            #region
            var mailMessage = new MailMessage(_mailSettings.Conta, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            #endregion

            #region enviando email
            var smtpClient = new SmtpClient(_mailSettings.Smtp, _mailSettings.Porta);

            smtpClient.Credentials = new NetworkCredential(_mailSettings.Conta, _mailSettings.Senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            
            #endregion
        }
    }
}
