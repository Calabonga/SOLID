using System.ComponentModel.Design;

namespace SOLID_D.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Container Creation

            var container = new SimpleIoC();
            var instance = new EmailService();
            container.RegisterInstance<IEmailService>(instance);

            #endregion

            #region Resolving

            var service1 = container.Resolve<IEmailService>();

            service1.Send();


            var service2 = container.Resolve<IEmailService>();

            service2.Send();

            #endregion
        }
    }
}
