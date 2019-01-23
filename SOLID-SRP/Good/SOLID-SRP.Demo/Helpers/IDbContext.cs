using System.Collections.Generic;
using SOLID_SRP.Demo.Models;

namespace SOLID_SRP.Demo.Helpers
{
    public interface IDbContext
    {
        /// <summary>
        /// Orders set emulation
        /// </summary>
        List<Order> Orders { get; set; }

        /// <summary>
        /// User set emulation
        /// </summary>
        List<User> Users { get; set; }

        /// <summary>
        /// Fakes the saving operation
        /// </summary>
        void SaveChanges();
    }
}