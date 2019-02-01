using Autofac;
using SOLID_SRP.Demo.Infrastructure.Factories;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Providers;
using SOLID_SRP.Demo.Infrastructure.Repositories;
using SOLID_SRP.Demo.Infrastructure.Service;

namespace SOLID_SRP.Demo.Infrastructure
{
    /// <summary>
    /// Dependency container (Autofac)
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// Returns instance of the <see cref="IContainer"/>
        /// </summary>
        /// <returns></returns>
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            
            // Providers
            builder.RegisterType<OrderProvider>().As<IOrderProvider>();

            // Services
            builder.RegisterType<OrderProvider>().As<IOrderProvider>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            // Other
            builder.RegisterType<EmailMessageFactory>().As<IEmailMessageFactory>();
            builder.RegisterType<NotificationProvider>().As<INotificationProvider>();
            
            var dbContext = new DbContext
            {
                Orders =  Database.GenerateOrders(),
                Users = Database.GenerateUsers()
            };
            builder.RegisterInstance(dbContext).As<IDbContext>();
            
            return builder.Build();
        }
    }
}