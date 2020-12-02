using System;
using AntDesign.Pro.Layout;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntDesignPro(this IServiceCollection services, Action<ProSettings> action)
        {
            services.AddAntDesign();
            services.Configure(action);
            return services;
        }

        public static IServiceCollection AddAntDesignPro(this IServiceCollection services, IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            services.AddAntDesign();
            services.Configure<ProSettings>(config.GetSection("ProSettings"));
            return services;
        }
    }
}