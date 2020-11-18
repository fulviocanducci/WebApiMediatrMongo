using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection Global(
            this IServiceCollection service
        )
        {
            return service.NameLowercaseUrlAndQueryStrings();
        }
        private static IServiceCollection NameLowercaseUrlAndQueryStrings(
            this IServiceCollection service
        )
        {
            service.AddRouting(config =>
            {
                config.LowercaseUrls = true;
                config.LowercaseQueryStrings = true;
            });
            return service;
        }
    }
}
