using Autofac;
using Demo.Package;
using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo.Helpers
{
    /// <summary>
    /// Autofac container initializer
    /// </summary>
    public static class AutofacContainer
    {
        /// <summary>
        /// Returns an instance of the <see cref="IContainer"/>
        /// </summary>
        /// <returns></returns>
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppSettingsManager>().AsSelf();
            builder.RegisterType<JsonSerializer>().As<IConfigSerializer<AppSettings>>();
            return builder.Build();
        }
    }
}