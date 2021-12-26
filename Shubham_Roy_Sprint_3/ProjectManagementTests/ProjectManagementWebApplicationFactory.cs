using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Common.Interfaces;
using ProjectManagement.Controllers.MockController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementTests
{
    public class ProjectManagementWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var appDBDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ProjectManagementDbContext>));

                var userRepositoryDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IRepository<User>));

                var projectRepositoryDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IRepository<Project>));

                var taskRepositoryDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IRepository<ProjectTask>));

                services.Remove(appDBDescriptor);
                services.Remove(userRepositoryDescriptor);
                services.Remove(projectRepositoryDescriptor);
                services.Remove(taskRepositoryDescriptor);

                services.AddDbContext<ProjectManagementDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDatabase");
                }, contextLifetime: ServiceLifetime.Singleton);
                services.AddSingleton<IRepository<User>, UserMockController>();
                services.AddSingleton<IRepository<ProjectTask>, TaskMockController>();
                services.AddSingleton<IRepository<Project>, ProjectMockController>();
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<ProjectManagementDbContext>();
                    dbContext.Database.EnsureCreated();
                }
            });
            builder.UseEnvironment("Testing");
        }
        
    }
}
