using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BigOn.Domain.AppCode.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions options;

        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpClient = new SmtpClient(options.SmtpHost, options.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(options.UserName, options.Password);
            smtpClient.EnableSsl = options.EnableSsl;

            var from = new MailAddress(options.UserName, options.DisplayName);
            var to = new MailAddress(toEmail);

            var mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
            return true;
        }
    }

    public class EmailServiceOptions
    {
        public string DisplayName { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
