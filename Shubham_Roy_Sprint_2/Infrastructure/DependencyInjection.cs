using Infrastructure.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<IProjectManagementDbContext>(serviceProvider => serviceProvider.GetService<ProjectManagementDbContext>());

            return services;
        }
    }
}
