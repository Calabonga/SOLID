using Autofac;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Service;

namespace SOLID_SRP.Demo
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            #region Dependecy container

            _container = AutofacContainer.Create();
            var orderService = _container.Resolve<IOrderService>();

            #endregion

            var orderId = 101;
            var newStatus = Status.Approved;

            PrintOrders("Before changes");

            var order = orderService.Checkout(orderId, newStatus);
            if (order == null)
            {
                Printer.PrintError("Order not found");
                return;
            }

            PrintOrders("After changed");

        }

        #region helpers

        static void PrintOrders(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Printer.PrintInfo(message);
            }
            Printer.Print("-----------------------------------------------------------------------");
            Printer.Print("| ORDERS                                                              |");
            Printer.Print("-----------------------------------------------------------------------");
            var db = _container.Resolve<IDbContext>();
            Printer.Print(db.Orders, o => $"{o.Id,6}  {o.Number,9} {o.Status, 10} {o.CreatedAt:d} {o.Customer.UserName,8}");
            Printer.Print("-----------------------------------------------------------------------");
        }

        #endregion
    }
}
