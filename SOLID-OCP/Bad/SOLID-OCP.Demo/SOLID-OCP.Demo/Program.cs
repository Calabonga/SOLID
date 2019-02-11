using Autofac;
using SOLID_OCP.Demo.Helpers;

namespace SOLID_OCP.Demo
{
    /// <summary>
    /// Open/Close Principle demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Container creations and some resolvings
            var container = AutofacContainer.Create();
            var notificationManager = container.Resolve<NotificationManager>();
            #endregion



            notificationManager.NotifyOrderNotFound(1010);
        }
    }
}