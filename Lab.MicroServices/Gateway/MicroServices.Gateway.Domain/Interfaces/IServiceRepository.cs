using MicroServices.Gateway.Domain.Entities;
using MicroServices.Infra.Common.Interfaces;

namespace MicroServices.Gateway.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
    }
}
