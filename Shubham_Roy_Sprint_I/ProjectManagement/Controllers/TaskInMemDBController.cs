using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class TaskInMemDBController : IRepository<ProjectTask>
    {
        readonly ProjectManagementDbContext _dbContext;

        public TaskInMemDBController(IServiceScopeFactory serviceProvider)
        {
            _dbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ProjectManagementDbContext>();
        }

        public ProjectTask Create(ProjectTask ProjectTask)
        {
            _dbContext.ProjectTasks.Add(ProjectTask);
            _dbContext.SaveChanges();
            return RetrieveByID(ProjectTask.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            try
            {
                var foundProjectTask = RetrieveByID(ID);
                _dbContext.ProjectTasks.Remove(foundProjectTask);
                _dbContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        public List<ProjectTask> RetrieveAll()
        {
            return _dbContext.ProjectTasks.ToList();
        }

        public ProjectTask RetrieveByID(int ID)
        {
            var foundProjectTask = _dbContext.ProjectTasks.FirstOrDefault(ProjectTask => ProjectTask.ID == ID);
            return foundProjectTask;
        }

        public ProjectTask Update(ProjectTask updatedProjectTask)
        {
            var foundProjectTask = RetrieveByID(updatedProjectTask.ID);
            if (foundProjectTask != null)
            {
                Delete(foundProjectTask.ID);
                Create(updatedProjectTask);
                _dbContext.SaveChanges();
            }
            return RetrieveByID(updatedProjectTask.ID);

        }
    }
}
