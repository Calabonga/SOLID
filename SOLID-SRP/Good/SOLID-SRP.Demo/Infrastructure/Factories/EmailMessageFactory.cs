using SOLID_SRP.Demo.Infrastructure.Models;
using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailMessageFactory: IEmailMessageFactory
    {
        /// <inheritdoc />
        public EmailMessage GetCustomerNotificationMessage(string email)
        {
            return new EmailMessage
            {
                Title = "Status changed",
                Message = $"Your order status was changed",
                Email = email
            };
        }

        /// <inheritdoc />
        public EmailMessage GetNotificationForAdministrator(int orderId, string email)
        {
            return new EmailMessage
            {
                Title = "Error",
                Message = $"Order not found {orderId}",
                Email = email
            };
        }

        
    }
}
