using Canducci.MongoDB.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Repositories;

namespace WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection Global(this IServiceCollection services)
        {
            services.AddLowerCaseUrl();
            services.AddConnectMongo();
            services.AddRepositories();
            services.AddMediatr();
            return services;
        }
        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Startup));            
        }

        private static IServiceCollection AddConnectMongo(this IServiceCollection services)
        {            
            return services.AddScoped<IConnect, Connect>();
        }

        private static IServiceCollection AddLowerCaseUrl(this IServiceCollection services)
        {
            return services.AddRouting(config =>
            {
                config.LowercaseUrls = true;
                config.LowercaseQueryStrings = true;
            });
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<FriendRepositoryAbstract, FriendRepository>();
        }

    }
}
