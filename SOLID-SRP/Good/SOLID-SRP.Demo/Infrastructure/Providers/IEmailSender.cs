using Calabonga.OperationResults;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    /// <summary>
    /// Notification provider
    /// </summary>
    public interface INotificationProvider
    {
        OperationResult<bool> NotifyAdminOrderNotFound(int orderId);

        void NotifyCustomerOrderUpdated(string email);
    }
}
