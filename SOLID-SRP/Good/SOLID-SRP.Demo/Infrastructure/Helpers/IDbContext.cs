using System.Collections.Generic;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    /// <summary>
    /// DbContext emulation
    /// </summary>
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