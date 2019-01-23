using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Models;

namespace SOLID_SRP.Demo.Service
{
    /// <summary>
    /// Interface for user management
    /// </summary>
    public interface IProfileService
    {
        User GetUserById(int userId);

        IEnumerable<User> GetAdministrators();
    }

    /// <summary>
    /// Implementation of <see cref="IProfileService"/>
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly IDbContext _context;

        public ProfileService(IDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(x => x.Id == userId);
        }

        public IEnumerable<User> GetAdministrators()
        {
            return _context.Users.Where(x => x.IsAdmin);
        }
    }
}
