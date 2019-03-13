using System;

namespace SOLID_LSP.Entities.Devices
{
    public class Device: IFax, ICopier, ITelephone, IScanner
    {
        public void SendFax()
        {
            throw new NotImplementedException();
        }

        public void CopyDocument()
        {
            throw new NotImplementedException();
        }

        public void MakeCall()
        {
            throw new NotImplementedException();
        }

        public void ScanDocument()
        {
            throw new NotImplementedException();
        }

        public void FlipPaper()
        {
            throw new NotImplementedException();
        }
    }
}
