using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// Interface for user management
    /// </summary>
    public interface IUserRepository
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
