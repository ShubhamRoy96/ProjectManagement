using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SeedDataGenerator
    {
        private readonly RequestDelegate _next;
        private static ProjectManagementDbContext _dbContext;

        public SeedDataGenerator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var dbContext = (ProjectManagementDbContext)context.RequestServices.GetService(typeof(ProjectManagementDbContext));
            await GenerateSeedData(dbContext);
            await _next(context);
        }

        public static async Task GenerateSeedData(ProjectManagementDbContext dbContext)
        {
            _dbContext = dbContext;

            await _dbContext.Users.AddRangeAsync(
                new User() { ID = 1, FirstName = "Shubham1", LastName = "Roy1", Email = "SR1@gmail.com", Password = "SRoyPwd1" },
                new User() { ID = 2, FirstName = "Shubham2", LastName = "Roy2", Email = "SR2@gmail.com", Password = "SRoyPwd2" },
                new User() { ID = 3, FirstName = "Shubham3", LastName = "Roy3", Email = "SR3@gmail.com", Password = "SRoyPwd3" },
                new User() { ID = 4, FirstName = "Shubham4", LastName = "Roy4", Email = "SR4@gmail.com", Password = "SRoyPwd4" }
                );
            await _dbContext.Projects.AddRangeAsync(
                new Project() { ID = 1, Name = "Project 1", Detail = "Project Details 1", CreatedOn = DateTime.Now },
                new Project() { ID = 2, Name = "Project 2", Detail = "Project Details 2", CreatedOn = DateTime.Now.AddHours(1) },
                new Project() { ID = 3, Name = "Project 3", Detail = "Project Details 3", CreatedOn = DateTime.Now.AddHours(2) },
                new Project() { ID = 4, Name = "Project 4", Detail = "Project Details 4", CreatedOn = DateTime.Now.AddHours(3) }
                );
            await _dbContext.ProjectTasks.AddRangeAsync(
                new ProjectTask() { ID = 1, ProjectID = 1, Status = 1, Detail = "Task Details 1", AssignedToUserID = 1, CreatedOn = DateTime.Now },
                new ProjectTask() { ID = 2, ProjectID = 2, Status = 2, Detail = "Task Details 2", AssignedToUserID = 2, CreatedOn = DateTime.Now.AddHours(1) },
                new ProjectTask() { ID = 3, ProjectID = 3, Status = 3, Detail = "Task Details 3", AssignedToUserID = 3, CreatedOn = DateTime.Now.AddHours(2) },
                new ProjectTask() { ID = 4, ProjectID = 4, Status = 4, Detail = "Task Details 4", AssignedToUserID = 4, CreatedOn = DateTime.Now.AddHours(3) }
                );
            await _dbContext.SaveChangesAsync();
        }
    }
}