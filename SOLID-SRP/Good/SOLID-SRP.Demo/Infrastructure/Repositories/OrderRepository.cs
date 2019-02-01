using System.Linq;
using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// Order service implementation
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _context;

        public OrderRepository(IDbContext context)
        {
            _context = context;
        }

        public OperationResult<Order> GetById(int orderId)
        {
            var operation = OperationResult.CreateResult<Order>();
            var order = _context.Orders.SingleOrDefault(x => x.Id == orderId);
            if (order == null)
            {
                operation.AddError(new OrderNotFoundException());
                return operation;
            }
            operation.Result = order;
            return operation;
        }

        /// <inheritdoc />
        public OperationResult<Order> ChangeStatus(int id, Status status)
        {
            var operation = OperationResult.CreateResult<Order>();
            var getOrderOperation = GetById(id);
            if (!getOrderOperation.Ok)
            {
                operation.AddError(getOrderOperation.Error);
                return operation;
            }

            var order = getOrderOperation.Result;
            order.Status = status;
            _context.SaveChanges();
            operation.Result = order;
            return operation;
        }
    }
}