using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Models;
using SOLID_SRP.Demo.Infrastructure.Repositories;
using SOLID_SRP.Demo.Infrastructure.Service;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationProvider _notificationProvider;

        public OrderProvider(
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            INotificationProvider emailService)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _notificationProvider = emailService;
        }

        /// <inheritdoc />
        public OperationResult<Order> ChangeStatus(int id, Status status)
        {
            var operation = OperationResult.CreateResult<Order>();
            var orderUpdateOperation = _orderRepository.ChangeStatus(id, status);
            if (!orderUpdateOperation.Ok)
            {
                var notifyOperation = _notificationProvider.NotifyAdminOrderNotFound(id);
                if (!notifyOperation.Ok)
                {
                    operation.AddError(new OrderNotFoundException(notifyOperation.Error));
                    return operation;
                }
                operation.AddError(orderUpdateOperation.Error);
                return operation;
            }

            var order = orderUpdateOperation.Result;
            var customer = _userRepository.GetUserById(order.Customer.Id);
            _notificationProvider.NotifyCustomerOrderUpdated(customer.Email);
            operation.Result = order;
            return operation;
        }
    }
}
