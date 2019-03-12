namespace SOLID_LSP.Entities.Devices
{
    public interface IDevice
    {
        void MakeCall();
        
        void SendFax();

        void ScanDocument();

        void CopyDocument();
    }
}
