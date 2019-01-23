using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.ViewModels;

namespace SOLID_SRP.Demo.Service
{
    /// <summary>
    /// Email service
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="message"></param>
        void Send(EmailMessage message);
    }

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
