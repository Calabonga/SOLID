using System.Linq;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Models;
using SOLID_SRP.Demo.ViewModels;

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
        public Order Approve(int id, Status status)
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
}
