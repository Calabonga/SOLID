using System.Linq;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Models;

namespace SOLID_SRP.Demo.Service
{
    public class OrderService : IOrderService
    {
        private readonly IDbContext _context;

        public OrderService(IDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Order Checkout(int id, Status status)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order == null)
            {
                var users = _context.Users.Where(x => x.IsAdmin).ToList();
                if (users.Any())
                {
                    foreach (var user in users)
                    {
                        var email = new EmailMessage
                        {
                            Title = "Error",
                            Message = "Order not found",
                            Email = user.Email
                        };
                        
                        var client = new SmtpClient();
                        
                        client.Send(email);
                    }
                }

                return null;
            }

            order.Status = status;
            _context.SaveChanges();

            var customer = order.Customer;
            var notification = new EmailMessage
            {
                Title = "Status changed",
                Message = $"Your order status was changed to {order.Status}",
                Email = customer.Email
            };

            var client1 = new SmtpClient();
            client1.Send(notification);
            return order;
        }
    }

    public class EmailMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }

    public interface IOrderService
    {
        /// <summary>
        /// Updates order current status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Order Checkout(int id, Status status);
    }
}
