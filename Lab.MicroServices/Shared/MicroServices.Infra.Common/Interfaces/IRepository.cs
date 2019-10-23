using System.Threading.Tasks;

namespace MicroServices.Infra.Common.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> Get(object id);
        Task Create(T entity);
        Task Update(object id, T entity);
        Task Delete(object id);
    }
}
