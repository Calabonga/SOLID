namespace SOLID_LSP.Entities.Cars
{
    public class Truck: Car
    {
        /// <summary>
        /// Type of the fuel
        /// </summary>
        public override FuelType FuelType
        {
            get { return FuelType.Diesel; }
        }

        /// <summary>
        /// Recharging hours
        /// </summary>
        public override int RechargeHours => 7;

        /// <summary>
        /// Number of  in fuel tank 
        /// </summary>
        public override int FuelTank => 220;

        /// <summary>
        /// Max speed, km/h
        /// </summary>
        public override int MaxSpeed => 110;
    }
}
