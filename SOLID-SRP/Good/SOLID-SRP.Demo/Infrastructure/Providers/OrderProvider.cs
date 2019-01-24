using System.Linq;
using Calabonga.OperationResults;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Models;
using SOLID_SRP.Demo.Infrastructure.Service;
using SOLID_SRP.Demo.Infrastructure.ViewModels;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IOrderService _orderService;
        private readonly IProfileService _profileService;
        private readonly INotificationProvider _notificationProvider;

        public OrderProvider(
            IOrderService orderService,
            IProfileService profileService,
            INotificationProvider emailService)
        {
            _orderService = orderService;
            _profileService = profileService;
            _notificationProvider = emailService;
        }

        /// <inheritdoc />
        public OperationResult<Order> ChangeStatus(int id, Status status)
        {
            var operation = OperationResult.CreateResult<Order>();
            var orderUpdateOperation = _orderService.ChangeStatus(id, status);
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
            var customer = _profileService.GetUserById(order.Customer.Id);
            _notificationProvider.NotifyCustomerOrderUpdated(customer.Email);
            operation.Result = order;
            return operation;
        }
    }
}
