using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo.Helpers
{
    /// <summary>
    /// Fake SmtpClient for demo purpose only
    /// </summary>
    public class SmtpClient
    {
        /// <summary>
        /// Fake send operation
        /// </summary>
        /// <param name="email"></param>
        public void Send(EmailMessage email)
        {
            // Imagine that the email successfully sent
            Logger.LogInfo($"Notification {email.Title} to {email.Email} sent");
        }
    }
}
