using MicroService.User.App.Interfaces;
using MicroService.User.App.Services;
using MicroServices.User.Domain.Interfaces;
using MicroServices.User.Infra.Extensions;
using MicroServices.User.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServices.User.Configs.Dependencies
{
    public static class UserContainerConfig
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Serices

            services.AddTransient<IClientApplicationService, ClientApplicationService>();

            #endregion Services

            #region Repositories

            services.AddTransient<IUnityOfWork, UnityOfWork>();

            #endregion

            services.AddDapper(configuration);
        }
    }
}
