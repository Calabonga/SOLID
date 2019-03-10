using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_LSP.Entities.Cars
{
    public interface ICanRecharge
    {
        int RechargeHours { get; }
    }
}
