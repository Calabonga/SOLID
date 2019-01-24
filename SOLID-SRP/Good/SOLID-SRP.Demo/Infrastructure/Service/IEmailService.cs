using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Service
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
}
