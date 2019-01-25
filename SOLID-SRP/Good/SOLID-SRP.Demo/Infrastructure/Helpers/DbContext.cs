using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    /// <summary>
    /// Implementation of <see cref="IDbContext"/> as faked EntityFramework context.
    /// </summary>
    public class DbContext : IDbContext
    {
        /// <inheritdoc />
        public List<Order> Orders { get; set; }

        /// <inheritdoc />
        public List<User> Users { get; set; }

        /// <inheritdoc />
        public void SaveChanges()
        {
            // save data to database
        }
    }
}