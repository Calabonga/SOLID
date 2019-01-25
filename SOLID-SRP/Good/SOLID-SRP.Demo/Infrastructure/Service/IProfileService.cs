using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Interface for user management
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Returns user by identifier
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserById(int userId);

        /// <summary>
        /// Returns all system administrators
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAdministrators();
    }
}
