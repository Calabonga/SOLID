using Calabonga.OperationResults;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    /// <summary>
    /// Notification provider
    /// </summary>
    public interface INotificationProvider
    {
        /// <summary>
        /// Notifies system administrators about order not found
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        OperationResult<bool> NotifyAdminOrderNotFound(int orderId);

        /// <summary>
        /// Notifies order owner about status changed
        /// </summary>
        /// <param name="email"></param>
        void NotifyCustomerOrderUpdated(string email);
    }
}
