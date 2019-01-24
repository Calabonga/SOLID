using System.Linq;
using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Order service implementation
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IDbContext _context;

        public OrderService(IDbContext context)
        {
            _context = context;
        }

        public OperationResult<Order> ChangeStatus(int id, Status status)
        {
            var operation = OperationResult.CreateResult<Order>();
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order== null)
            {
                operation.AddError(new OrderNotFoundException());
                return operation;
            }

            order.Status = status;
            _context.SaveChanges();
            operation.Result = order;
            return operation;
        }
    }
}