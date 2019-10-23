using MicroServices.Gateway.Domain.Entities;
using System.Threading.Tasks;

namespace MicroServices.Gateway.App.Interfaces
{
    public interface IServiceApplicationService
    {
        Task<Service> GetService(string name);
    }
}
