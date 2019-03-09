using System.Runtime.InteropServices;

namespace SOLID_LSP.Entities.Cars
{
    /// <summary>
    /// Car base class
    /// </summary>
    public abstract class Car
    {
        /// <summary>
        /// Type of the fuel
        /// </summary>
        public abstract FuelType FuelType { get; }

        /// <summary>
        /// Recharging hours
        /// </summary>
        public abstract int RechargeHours { get; }

        /// <summary>
        /// Number of  in fuel tank 
        /// </summary>
        public abstract int FuelTank { get; }

        /// <summary>
        /// Max speed
        /// </summary>
        public abstract int MaxSpeed { get; }
    }
}
