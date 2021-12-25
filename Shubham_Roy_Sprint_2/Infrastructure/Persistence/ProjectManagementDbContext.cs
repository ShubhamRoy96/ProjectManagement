using Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProjectManagementDbContext : DbContext, IProjectManagementDbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {
            
        }

        DbSet<User> _user;
        DbSet<ProjectTask> _task;
        DbSet<Project> _project;

        public DbSet<User> Users { get => _user; set => _user = value; }
        public DbSet<ProjectTask> ProjectTasks { get => _task; set => _task = value; }
        public DbSet<Project> Projects { get => _project; set => _project = value; }
    }
}
