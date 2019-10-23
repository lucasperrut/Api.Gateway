using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace MicroServices.Gateway.App.Builders
{
    public class RequestMessageBuilder
    {
        private HttpRequestMessage _message;

        public RequestMessageBuilder(string method, string url)
        {
            _message = new HttpRequestMessage(new HttpMethod(method), url);
        }

        public RequestMessageBuilder FromRequest(HttpRequest request)
        {
            if (_message.Method != HttpMethod.Get && request.ContentLength != null && request.ContentLength.HasValue)
                _message.Content = new StreamContent(request.Body);

            return this;
        }

        public HttpRequestMessage Build()
        {
            return _message;
        }
    }
}
