using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    public class DbContext : IDbContext
    {
        /// <inheritdoc />
        public List<Order> Orders { get; set; }

        /// <inheritdoc />
        public List<User> Users { get; set; }

        /// <inheritdoc />
        public void SaveChanges()
        {
            //throw new System.NotImplementedException();
        }
    }
}