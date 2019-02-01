using System.Linq;
using Calabonga.OperationResults;
using SOLID_SRP.Demo.Exceptions;
using SOLID_SRP.Demo.Infrastructure.Factories;
using SOLID_SRP.Demo.Infrastructure.Repositories;
using SOLID_SRP.Demo.Infrastructure.Service;

namespace SOLID_SRP.Demo.Infrastructure.Providers
{
    /// <summary>
    /// Notification sender (provider)
    /// </summary>
    public class NotificationProvider : INotificationProvider
    {
        private readonly IEmailService _emailService;
        private readonly IEmailMessageFactory _factory;
        private readonly IUserRepository _userRepository;

        public NotificationProvider(IEmailService emailService, IEmailMessageFactory factory, IUserRepository userRepository)
        {
            _emailService = emailService;
            _factory = factory;
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public OperationResult<bool> NotifyAdminOrderNotFound(int orderId)
        {
            var operation = OperationResult.CreateResult<bool>();
            var admins = _userRepository.GetAdministrators().ToList();
            if (admins.Any())
            {
                foreach (var user in admins)
                {
                    var email = _factory.GetNotificationForAdministrator(orderId, user.Email);
                    _emailService.Send(email);
                }

                operation.Result = true;
                operation.AddSuccess($"Totally messages sent: {admins.Count}");
                return operation;
            }
            operation.AddError(new AdministratorNotFoundException());
            return operation;
        }

        /// <inheritdoc />
        public void NotifyCustomerOrderUpdated(string address)
        {
            var email = _factory.GetCustomerNotificationMessage(address);
            _emailService.Send(email);
        }
    }
}