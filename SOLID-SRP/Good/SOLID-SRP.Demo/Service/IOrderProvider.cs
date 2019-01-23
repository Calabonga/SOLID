using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Models;

namespace SOLID_SRP.Demo.Service
{
    /// <summary>
    /// Order service
    /// </summary>
    public interface IOrderProvider
    {
        /// <summary>
        /// Updates order current status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Order Approve(int id, Status status);
    }
}