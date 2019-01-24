using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Order service
    /// </summary>
    public interface IOrderService
    {
        OperationResult<Order> ChangeStatus(int id, Status status);
    }
}
