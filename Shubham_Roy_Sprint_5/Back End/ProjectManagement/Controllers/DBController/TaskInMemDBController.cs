using Domain.Entities;
using Infrastructure.Common.Interfaces;
using ProjectManagement.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Controllers.DBController
{
    public class TaskInMemDBController : IRepository<ProjectTask>
    {
        private readonly IProjectManagementDbContext _dbContext;

        public TaskInMemDBController(IProjectManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectTask Create(ProjectTask ProjectTask)
        {
            ProjectTask.CreatedOn = DateTime.Now;
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