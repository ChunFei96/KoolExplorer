using Core.Configuration;
using Core.Domain.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName, System.Text.Encoding.UTF8);
                mail.Subject = mailRequest.Subject;
                mail.Body = mailRequest.Body;
                mail.To.Add(mailRequest.ToEmail);
                mail.Bcc.Add(_mailSettings.Mail);
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                smtp.Port = _mailSettings.Port;
                smtp.Host = _mailSettings.Host;
                smtp.EnableSsl = true;
               
                await smtp.SendMailAsync(mail);
                mail.Dispose();
            }
            catch(Exception e)
            {
                var aa = 0;
            }
        }
    }
}
