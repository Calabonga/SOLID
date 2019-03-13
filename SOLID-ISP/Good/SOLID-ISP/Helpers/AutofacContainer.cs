using System.Net;
using Autofac;
using SOLID_LSP.Entities.Shapes;

namespace SOLID_LSP.Helpers
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
            builder.RegisterType<Circle>().As<ICircle>();
            builder.RegisterType<Triangle>().As<ITriangle>();
            builder.RegisterType<Square>().As<ISquare>();
            builder.RegisterType<Rectangle>().As<IRectangle>();

            builder.RegisterType<Circle>().As<ICanDraw>();
            builder.RegisterType<Triangle>().As<ICanDraw>();
            builder.RegisterType<Square>().As<ICanDraw>();
            builder.RegisterType<Rectangle>().As<ICanDraw>();

            builder.RegisterType<DrawMachine>().AsSelf();

            return builder.Build();
        }
    }
}