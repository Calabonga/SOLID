using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Email service implementation
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _client;
        public EmailService()
        {
            _client = new SmtpClient();
        }

        public void Send(EmailMessage message)
        {
            _client.Send(message);
        }
    }
}