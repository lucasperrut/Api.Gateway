using MicroServices.Gateway.App.Interfaces;
using MicroServices.Gateway.Domain.Entities;
using System.Threading.Tasks;

namespace MicroServices.Gateway.App.Services
{
    public class ServiceApplicationService : IServiceApplicationService
    {
        public Task<Service> GetService(string name)
        {
            var service = new Service();
            switch (name)
            {
                case "user":
                    service.Name = "Client";
                    service.BaseUrl = "http://localhost:3010";
                    break;
                case "notification":
                    service.Name = "Client";
                    service.BaseUrl = "http://localhost:3020";
                    break;
                default:
                    break;
            }

            return Task.FromResult(service);
        }
    }
}
