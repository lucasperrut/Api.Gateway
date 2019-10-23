using MicroServices.Gateway.App.Builders;
using MicroServices.Gateway.App.Interfaces;
using MicroServices.Gateway.Domain.Entities;
using MicroServices.Infra.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroServices.Gateway.App.Services
{
    public class DispatcherService : IDispatcherService
    {
        private readonly IServiceApplicationService _serviceApplicationService;
        private readonly IUserAgent _userAgent;

        public DispatcherService(IServiceApplicationService serviceApplicationService, IUserAgent userAgent)
        {
            _serviceApplicationService = serviceApplicationService;
            _userAgent = userAgent;
        }

        public async Task<HttpResponseMessage> DispatcherRequest(HttpRequest request)
        {
            var urlParams = GetUrlParams(request);

            var serviceName = urlParams.Groups["service"].Value;
            var path = urlParams.Groups["path"].Value;

            var service = await GetService(serviceName);

            var url = BuildUrl(request, service, path);
            var requestMessage = BuildRequestMessage(request, url);

            return await ExecuteRequest(requestMessage);
        }

        private Match GetUrlParams(HttpRequest request)
        {
            var regex = new Regex("/svc/(?<service>.+?)/(?<path>'?.*'?)");
            return regex.Match(request.Path.Value);
        }

        private async Task<Service> GetService(string serviceName)
        {
            var service = await _serviceApplicationService.GetService(serviceName);

            if (service != null)
                return service;

            throw new Exception(); //TODO: HttpException
        }

        private string BuildUrl(HttpRequest request, Service service, string path)
        {
            return new RequestUrlBuider(service.BaseUrl)
                .Append(path)
                .Append(request.QueryString.Value)
                .Build();
        }

        private HttpRequestMessage BuildRequestMessage(HttpRequest request, string url)
        {
            return new RequestMessageBuilder(request.Method, url).FromRequest(request).Build();
        }

        private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage requestMessage)
        {
            var response = await _userAgent.Send(requestMessage);

            if (response.IsSuccessStatusCode)
                return response;

            throw new Exception(); //HttpException
        }
    }
}
