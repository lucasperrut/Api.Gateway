using MicroServices.Infra.Common.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServices.Infra.Common.Http
{
    public class UserAgent : IUserAgent
    {
        public async Task<HttpResponseMessage> Send(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    return await client.SendAsync(request);
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
