using System;

namespace SOLID_D.Demo
{
    public class EmailService : IEmailService
    {
        public void Send()
        {
            Console.WriteLine("Message sent!");
        }
    }
}