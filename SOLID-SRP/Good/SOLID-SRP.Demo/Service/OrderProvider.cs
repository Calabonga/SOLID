using System.Linq;
using SOLID_SRP.Demo.Enumerations;
using SOLID_SRP.Demo.Helpers;
using SOLID_SRP.Demo.Models;
using SOLID_SRP.Demo.ViewModels;

namespace SOLID_SRP.Demo.Service
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IOrderService _orderService;
        private readonly IProfileService _profileService;
        private readonly IEmailService _emailService;

        public OrderProvider(
            IOrderService orderService,
            IProfileService profileService,
            IEmailService emailService)
        {
            _orderService = orderService;
            _profileService = profileService;
            _emailService = emailService;
        }

        /// <inheritdoc />
        public Order Approve(int id, Status status)
        {
            var order = _orderService.Approve(id, status);
            if (order == null)
            {
                var admins = _profileService.GetAdministrators().ToList();
                if (admins.Any())
                {
                    foreach (var user in admins)
                    {
                        var email = new EmailMessage
                        {
                            Title = "Error",
                            Message = "Order not found",
                            Email = user.Email
                        };
                        _emailService.Send(email);
                    }
                }

                return null;
            }

            var customer = _profileService.GetUserById(order.Customer.Id);
            var notification = new EmailMessage
            {
                Title = "Status changed",
                Message = $"Your order status was changed to {order.Status}",
                Email = customer.Email
            };
            _emailService.Send(notification);
            return order;
        }
    }
}
