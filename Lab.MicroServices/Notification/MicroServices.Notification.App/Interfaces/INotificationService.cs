using System.Threading.Tasks;

namespace MicroServices.Notification.App.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(Domain.Entities.Notification notification);
    }
}
