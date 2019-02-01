using System.Linq;
using Calabonga.OperationResults;
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

        /// <summary>
        /// Returns Order from database
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public OperationResult<Order> Update(Order order)
        {
            var operation = OperationResult.CreateResult<Order>();
            _context.SaveChanges();
            operation.Result = order;
            return operation;
        }
    }
}