﻿using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Helpers
{
    /// <summary>
    /// Fake SmtpClient for demo purpose only
    /// </summary>
    public class SmtpClient
    {
        /// <summary>
        /// Fake send operation
        /// </summary>
        /// <param name="email"></param>
        public void Send(EmailMessage email)
        {
            // Imagine that the email successfully sent
        }
    }
}
