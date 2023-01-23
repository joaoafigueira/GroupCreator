using Microsoft.Extensions.DependencyInjection;
using RandomGroupCreator.Domain.Interfaces.Services;
using RandomGroupCreator.Domain.Services;

namespace RandomGroupCreator.Domain.Configurations
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IRandomGroupService, RandomGroupService>();

            return services;
        }
    }
}
