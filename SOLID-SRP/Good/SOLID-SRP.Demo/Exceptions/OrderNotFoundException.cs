using System;

namespace SOLID_SRP.Demo.Exceptions
{
    /// <summary>
    /// Order not found exception
    /// </summary>
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base("Order not found")
        {

        }

        public OrderNotFoundException(string message) : base($"Order not found: {message}")
        {

        }

        public OrderNotFoundException(Exception exception) : base($"Order not found", exception)
        {
        }

        public OrderNotFoundException(string message, Exception exception) : base($"Order not found: {message}", exception)
        {
        }
    }
}
