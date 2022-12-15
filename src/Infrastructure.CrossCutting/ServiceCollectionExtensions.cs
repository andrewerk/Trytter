using Infrastructure.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddDbService();

            return services;
        }
    }
}