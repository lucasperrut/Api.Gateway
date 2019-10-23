using MicroServices.Notification.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace MicroServices.Notification.Infra.Providers
{
    public class EmailNotification : IEmailNotification
    {
        public Task Notify(Domain.Entities.Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
