using MicroServices.User.Domain.Entities;
using System.Threading.Tasks;

namespace MicroService.User.App.Interfaces
{
    public interface IClientApplicationService
    {
        Task<Client> GetClient(int id);
        Task CreateClient(Client client);
        Task EditClient(int id, Client client);
        Task DeleteClient(int id);
    }
}
