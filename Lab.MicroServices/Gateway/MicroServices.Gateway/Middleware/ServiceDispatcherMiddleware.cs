using MicroServices.Gateway.App.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MicroServices.Gateway.Middleware
{
    public class ServiceDispatcherMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDispatcherService _dispatcherService;

        public ServiceDispatcherMiddleware(RequestDelegate next, IDispatcherService dispatcherService)
        {
            _next = next;
            _dispatcherService = dispatcherService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.Request.Path.Value.Contains("/svc/"))
                    await _dispatcherService.DispatcherRequest(context.Request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
