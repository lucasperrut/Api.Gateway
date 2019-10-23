using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServices.Infra.Common.Interfaces
{
    public interface IUserAgent
    {
        Task<HttpResponseMessage> Send(HttpRequestMessage request);
    }
}
