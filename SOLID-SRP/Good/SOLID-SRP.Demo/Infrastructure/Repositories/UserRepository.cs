using System.Collections.Generic;
using System.Linq;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IUserRepository"/>
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _context;

        public UserRepository(IDbContext context)
        {
            _context = context;
        }


        /// <inheritdoc />
        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(x => x.Id == userId);
        }

        /// <inheritdoc />
        public IEnumerable<User> GetAdministrators()
        {
            return _context.Users.Where(x => x.IsAdmin);
        }
    }
}