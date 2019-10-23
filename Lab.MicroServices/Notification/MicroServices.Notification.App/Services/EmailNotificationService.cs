using MicroServices.Notification.App.Interfaces;
using MicroServices.Notification.Infra.Interfaces;
using System.Threading.Tasks;

namespace MicroServices.Notification.App.Services
{
    public class EmailNotificationService : INotificationService
    {
        private IEmailNotification _notification;

        public EmailNotificationService(IEmailNotification notification)
        {
            _notification = notification;
        }

        public async Task SendNotification(Domain.Entities.Notification notification)
        {
            await _notification.Notify(notification);
        }
    }
}
