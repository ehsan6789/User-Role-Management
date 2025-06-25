using System.Net.Mail;
using System.Net;
using AUTHDEMO1.Interfaces;

namespace AUTHDEMO1.Services
{

    // In Authdemo1.Services.EmailSender.cs
    public class EmailSender : ICustomEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_config["SmtpSettings:Host"], int.Parse(_config["SmtpSettings:Port"]))
            {
                Credentials = new NetworkCredential(_config["SmtpSettings:SenderEmail"], _config["SmtpSettings:SenderPassword"]),
                EnableSsl = true
            };

            await client.SendMailAsync(new MailMessage(_config["SmtpSettings:SenderEmail"], email, subject, htmlMessage) { IsBodyHtml = true });
        }
    }


}