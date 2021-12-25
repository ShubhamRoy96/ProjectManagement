using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Services.DBController
{
    public class ProjectInMemDBController : IRepository<Project>
    {
        private readonly ProjectManagementDbContext _dbContext;

        public ProjectInMemDBController(IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ProjectManagementDbContext>();
        }

        public Project Create(Project Project)
        {
            Project.CreatedOn = DateTime.Now;
            _dbContext.Projects.Add(Project);
            _dbContext.SaveChanges();
            return RetrieveByID(Project.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            var foundProject = RetrieveByID(ID);
            _dbContext.Projects.Remove(foundProject);
            _dbContext.SaveChanges();
            isSuccess = true;

            return isSuccess;
        }

        public List<Project> RetrieveAll()
        {
            return _dbContext.Projects.ToList();
        }

        public Project RetrieveByID(int ID)
        {
            var foundProject = _dbContext.Projects.FirstOrDefault(Project => Project.ID == ID);
            if (foundProject == default(Project))
            {
                return null;
            }
            return foundProject;
        }

        public Project Update(Project updatedProject)
        {
            var foundProject = RetrieveByID(updatedProject.ID);
            if (foundProject != null)
            {
                Delete(foundProject.ID);
                Create(updatedProject);
                _dbContext.SaveChanges();
            }

            return RetrieveByID(updatedProject.ID);
        }
    }
}