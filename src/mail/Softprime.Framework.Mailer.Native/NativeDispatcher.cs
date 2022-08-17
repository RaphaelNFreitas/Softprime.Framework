using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Softprime.Framework.Mailer.Models;

namespace Softprime.Framework.Mailer.Native
{
    public class NativeDispatcher : ISoftprimeMailerDispatcher
    {
        private readonly NativeSettings _nativeSettings;

        public NativeDispatcher(NativeSettings nativeSettings)
        {
            _nativeSettings = nativeSettings;
        }

        public async Task<MailerResponse> Send(MailAddress from, 
            MailAddress to, 
            string subject, 
            string htmlContent, 
            string plainTextContent = null,
            MailPriority priority = MailPriority.Normal,
            Attachment[] attachments = null)
        {
            try
            {
                var client = new SmtpClient(_nativeSettings.SmtpEmailHost, _nativeSettings.SmtpPortHost)
                {
                    EnableSsl = _nativeSettings.EnableSsl
                };

                client.Credentials =
                    new NetworkCredential(_nativeSettings.EmailHost, _nativeSettings.PasswordEmailHost);

                var mailMessage = new MailMessage(from.Address, to.Address, subject, htmlContent);
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = priority;

                client.Send(mailMessage);

                return new MailerResponse
                {
                    Sent = true
                };
            }
            catch (Exception exception)
            {
                return new MailerResponse
                {
                    Sent = false,
                    ErrorMessages = new List<string>(new[] { exception.Message })
                };
            }
        }
    }
}