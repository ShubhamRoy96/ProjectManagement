using Domain.Entities;
using Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ProjectManagementDbContext : DbContext, IProjectManagementDbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {
        }

        private DbSet<User> _user;
        private DbSet<ProjectTask> _task;
        private DbSet<Project> _project;

        public DbSet<User> Users { get => _user; set => _user = value; }
        public DbSet<ProjectTask> ProjectTasks { get => _task; set => _task = value; }
        public DbSet<Project> Projects { get => _project; set => _project = value; }
    }
}