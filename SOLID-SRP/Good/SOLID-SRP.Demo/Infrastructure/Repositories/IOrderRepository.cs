using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// Order service
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Updates status for order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        OperationResult<Order> ChangeStatus(int id, Status status);
    }
}
