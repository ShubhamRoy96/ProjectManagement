using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace Infrastructure.Common.Interfaces
{
    internal interface IProjectManagementDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}