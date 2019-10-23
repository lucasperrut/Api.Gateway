using System.Threading.Tasks;

namespace MicroServices.Notification.Infra.Interfaces
{
    public interface INotification
    {
        Task Notify(Domain.Entities.Notification notification);
    }
}
