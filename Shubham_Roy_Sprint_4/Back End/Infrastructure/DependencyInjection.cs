using Infrastructure.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
        {
            services.AddDbContext<ProjectManagementDbContext>(options =>
            {
                options.UseInMemoryDatabase("ProjectManagementDatabase");
            }, contextLifetime: ServiceLifetime.Singleton
            );

            services.AddSingleton<IProjectManagementDbContext>(serviceProvider => serviceProvider.GetService<ProjectManagementDbContext>());

            return services;
        }
    }
}