using Autofac;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Service;

namespace SOLID_SRP.Demo
{
    public static class AutofacContainer
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderService>().As<IOrderService>();

            var dbContext = new DbContext
            {
                Orders =  Database.GenerateOrders(),
                Users = Database.GenerateUsers()
            };
            builder.RegisterInstance(dbContext).As<IDbContext>().SingleInstance();

            return builder.Build();
        }
    }
}