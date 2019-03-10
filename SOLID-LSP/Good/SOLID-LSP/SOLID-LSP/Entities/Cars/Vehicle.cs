namespace SOLID_LSP.Entities.Cars
{
    /// <summary>
    /// Vehicle base class
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// Type of the fuel
        /// </summary>
        public abstract FuelType FuelType { get; }

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
