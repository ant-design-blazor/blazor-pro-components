using System;
using AntDesign.Pro.Layout;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntDesignProLayout(this IServiceCollection services, Action<ProSettings> action)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            services.Configure(action);
            return services;
        }

        public static IServiceCollection AddAntDesignProLayout(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            services.Configure<ProSettings>(config.GetSection("ProSettings"));
            return services;
        }
    }
}
