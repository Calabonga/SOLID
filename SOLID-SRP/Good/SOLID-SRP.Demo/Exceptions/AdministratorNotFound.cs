using System;

namespace SOLID_SRP.Demo.Exceptions
{
    /// <summary>
    /// Order not found exception
    /// </summary>
    public class AdministratorNotFoundException : Exception
    {
        public AdministratorNotFoundException() : base("Administrators are not found")
        {

        }

        public AdministratorNotFoundException(string message) : base($"Administrators are not found: {message}")
        {

        }

        public AdministratorNotFoundException(Exception exception) : base($"Administrators are not found", exception)
        {
        }

        public AdministratorNotFoundException(string message, Exception exception) : base($"Administrators are not found: {message}", exception)
        {
        }
    }
}
