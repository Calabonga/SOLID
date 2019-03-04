using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_OCP.Demo.Helpers;

namespace SOLID_LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Container creations and some resolvings
            var container = AutofacContainer.Create();
            var settingsManager = container.Resolve<AppSettingsManager>();
            #endregion
        }
    }
}
