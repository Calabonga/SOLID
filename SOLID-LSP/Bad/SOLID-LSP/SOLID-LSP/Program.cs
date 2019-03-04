using SOLID_OCP.Demo.Helpers;

namespace SOLID_LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Container creations and some resolvings
            var container = AutofacContainer.Create();
            //resolve types you need
            //var settingsManager = container.Resolve<AppSettingsManager>();
            #endregion
        }
    }
}
