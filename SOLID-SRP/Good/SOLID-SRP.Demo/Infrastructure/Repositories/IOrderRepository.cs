using Calabonga.OperationResults;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// Order service
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Returns Order from database
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        OperationResult<Order> GetById(int orderId);

        /// <summary>
        /// Updates order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        OperationResult<Order> Update(Order order);
    }
}
