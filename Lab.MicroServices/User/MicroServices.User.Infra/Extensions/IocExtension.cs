using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace MicroServices.User.Infra.Extensions
{
    public static class IocExtension
    {
        public static void AddDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnection>(x => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
