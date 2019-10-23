using MicroService.User.App.Interfaces;
using MicroServices.User.Domain.Entities;
using MicroServices.User.Domain.Interfaces;
using System.Threading.Tasks;

namespace MicroService.User.App.Services
{
    public class ClientApplicationService : IClientApplicationService
    {
        private IUnityOfWork _unityOfWork;

        public ClientApplicationService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task CreateClient(Client client)
        {
            await _unityOfWork.ClientRepository.Create(client);
        }

        public async Task DeleteClient(int id)
        {
            await _unityOfWork.ClientRepository.Delete(id);
        }

        public async Task EditClient(int id, Client client)
        {
            await _unityOfWork.ClientRepository.Update(id, client);
        }

        public async Task<Client> GetClient(int id)
        {
            return await _unityOfWork.ClientRepository.Get(id);
        }
    }
}
