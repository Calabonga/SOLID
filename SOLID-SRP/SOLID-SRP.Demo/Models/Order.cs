using System;
using SOLID_SRP.Demo.Enumerations;

namespace SOLID_SRP.Demo.Models
{
    /// <summary>
    /// Business order
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime CreatedAt { get; set; }

        public Status Status { get; set; }

        public User Customer { get; set; }
    }
}
