using Microsoft.Extensions.DependencyInjection;
using Product.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection RegisterServiceLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IResourceTextService, ResourceService>();
            services.AddScoped<IManualLog,ManualLogService>();
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
