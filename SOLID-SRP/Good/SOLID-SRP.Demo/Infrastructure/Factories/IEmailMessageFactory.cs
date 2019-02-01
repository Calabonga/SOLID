using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Factories
{
    /// <summary>
    /// Email message factory
    /// </summary>
    public interface IEmailMessageFactory
    {
        /// <summary>
        /// Returns email message for customer
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        EmailMessage GetCustomerNotificationMessage(string email);

        /// <summary>
        /// Returns email message for administrator
        /// </summary>
        /// <returns></returns>
        EmailMessage GetNotificationForAdministrator(int orderId, string email);
    }
}