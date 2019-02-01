using Autofac;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Infrastructure;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Providers;

namespace SOLID_SRP.Demo
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            #region Dependecy container

            _container = DependencyContainer.Create();
            var orderProvider = _container.Resolve<IOrderProvider>();

            #endregion

            var orderId = 101;
            var newStatus = Status.Approved;

            PrintOrders("Before changes");

            var changeOrderOperation = orderProvider.ChangeStatus(orderId, newStatus);
            if (!changeOrderOperation.Ok)
            {
                Logger.LogError(changeOrderOperation.Error);
                return;
            }

            PrintOrders("After changed");
        }

        #region helpers

        static void PrintOrders(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Logger.LogInfo(message);
            }
            Logger.Print("-----------------------------------------------------------------------");
            Logger.Print("| ORDERS                                                              |");
            Logger.Print("-----------------------------------------------------------------------");
            var db = _container.Resolve<IDbContext>();
            Logger.Print(db.Orders, o => $"{o.Id,6}  {o.Number,9} {o.Status, 10} {o.CreatedAt:d} {o.Customer.UserName,8}");
            Logger.Print("-----------------------------------------------------------------------");
        }

        #endregion
    }
}
