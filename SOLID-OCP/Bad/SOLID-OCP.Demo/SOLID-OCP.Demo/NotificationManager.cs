using SOLID_OCP.Demo.Helpers;
using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo
{
    /// <summary>
    /// Notification manager
    /// </summary>
    public class NotificationManager
    {
        /// <summary>
        /// Send notification to administrator about order not found
        /// </summary>
        /// <param name="number"></param>
        public void NotifyOrderNotFound(int number)
        {
            var message = new EmailMessage
            {
                Title = "Order issue",
                Message = $"Order not found, check order number {number}",
                Email = "dev@calabonga.net",
            };
            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
