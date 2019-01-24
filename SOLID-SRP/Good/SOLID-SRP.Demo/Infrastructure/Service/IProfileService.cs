using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Interface for user management
    /// </summary>
    public interface IProfileService
    {
        User GetUserById(int userId);

        IEnumerable<User> GetAdministrators();
    }
}
