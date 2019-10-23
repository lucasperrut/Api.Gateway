using MicroServices.Infra.Common.Interfaces;

namespace MicroServices.User.Domain.Interfaces
{
    public interface IUnityOfWork : ITransactionManager
    {
        IClientRepository ClientRepository { get; }
    }
}
