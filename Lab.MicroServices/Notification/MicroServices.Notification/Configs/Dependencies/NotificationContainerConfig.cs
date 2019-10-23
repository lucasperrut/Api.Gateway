using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroServices.Notification.Configs.Dependencies
{
    public class NotificationContainerConfig
    {
        public static IServiceProvider Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
