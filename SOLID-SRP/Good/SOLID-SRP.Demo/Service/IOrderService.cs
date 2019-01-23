using System.Linq;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Models;

namespace SOLID_SRP.Demo.Service
{
    public interface IOrderService
    {
        Order Approve(int id, Status status);
    }

    public class OrderService : IOrderService
    {
        private readonly IDbContext _context;

        public OrderService(IDbContext context)
        {
            _context = context;
        }

        public Order Approve(int id, Status status)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order== null)
            {
                return null;
            }

            order.Status = status;
            _context.SaveChanges();
            return order;
        }
    }
}
