namespace SOLID_LSP.Entities.Cars
{
    public abstract class ElectricVehicle : Vehicle, ICanRecharge
    {
        /// <summary>
        /// Recharging hours
        /// </summary>
        public abstract int RechargeHours { get; }
    }
}