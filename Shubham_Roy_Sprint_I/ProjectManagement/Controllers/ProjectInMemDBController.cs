using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectInMemDBController : IRepository<Project>
    {
        readonly ProjectManagementDbContext _dbContext;

        public ProjectInMemDBController(IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ProjectManagementDbContext>();
        }

        public Project Create(Project Project)
        {
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
