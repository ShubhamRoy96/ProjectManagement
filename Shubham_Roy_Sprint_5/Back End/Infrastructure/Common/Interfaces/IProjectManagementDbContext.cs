using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Interfaces
{
    public interface IProjectManagementDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public int SaveChanges();
    }
}