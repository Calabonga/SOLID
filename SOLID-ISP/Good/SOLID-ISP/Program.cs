using System.Net.Mime;
using Autofac;
using SOLID_LSP.Entities.Shapes;
using SOLID_LSP.Helpers;

namespace SOLID_LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Container

            var container = AutofacContainer.Create();

            #endregion

            var machine = container.Resolve<DrawMachine>();

            machine.DrawAll();
        }
    }
}
