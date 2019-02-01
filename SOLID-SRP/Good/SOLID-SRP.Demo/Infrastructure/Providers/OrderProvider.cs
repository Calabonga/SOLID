using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Models;
using SOLID_SRP.Demo.Infrastructure.Repositories;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderProvider(
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            INotificationProvider emailService)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public OperationResult<Order> ChangeStatus(int id, Status status)
        {
            var operation = OperationResult.CreateResult<Order>();
            var orderUpdateOperation = _orderRepository.GetById(id);
            if (!orderUpdateOperation.Ok)
            {
                operation.AddError(orderUpdateOperation.Error);
                return operation;
            }

            var order = orderUpdateOperation.Result;
            order.Status = status;
            _orderRepository.Update(order);
            operation.Result = order;
            return operation;
        }
    }
}
