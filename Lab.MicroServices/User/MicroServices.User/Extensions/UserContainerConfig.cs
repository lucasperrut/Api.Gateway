using MicroServices.User.Infra.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServices.User.Extensions
{
    public static class UserContainerConfig
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDapper(configuration);
        }
    }
}
