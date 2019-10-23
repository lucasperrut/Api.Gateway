using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServices.Gateway.App.Interfaces
{
    public interface IDispatcherService
    {
        Task<HttpResponseMessage> DispatcherRequest(HttpRequest request);
    }
}
