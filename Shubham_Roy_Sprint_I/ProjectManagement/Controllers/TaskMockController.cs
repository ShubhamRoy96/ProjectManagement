using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class TaskMockController : IRepository<ProjectTask>
    {
        List<ProjectTask> projectTasksList = new List<ProjectTask>()
        {
            new ProjectTask(){ ID = 1, ProjectID = 1, Status = 1, AssignedToUserID = 1, Detail = "A task", CreatedOn = new DateTime(2021,12,1)},
            new ProjectTask(){ ID = 2, ProjectID = 2, Status = 2, AssignedToUserID = 2, Detail = "A good task", CreatedOn = new DateTime(2021,2,12)},
            new ProjectTask(){ ID = 3, ProjectID = 3, Status = 3, AssignedToUserID = 4, Detail = "A boring task", CreatedOn = new DateTime(2021,3,14)},
            new ProjectTask(){ ID = 4, ProjectID = 4, Status = 4, AssignedToUserID = 3, Detail = "An Awesome task!", CreatedOn = new DateTime(2021,5,21)},
        };
                
        public ProjectTask Create(ProjectTask newProjectTask)
        {
            if (GetProjectTask(newProjectTask.ID) == null)
            {
                newProjectTask.CreatedOn = DateTime.Now;
                projectTasksList.Add(newProjectTask);
            }
            else
                return null;
            
            return RetrieveByID(newProjectTask.ID);
        }

        public List<ProjectTask> RetrieveAll()
        {
            return projectTasksList;
        }

        public ProjectTask RetrieveByID(int ID)
        {
            var retrievedProjectTask = GetProjectTask(ID);            
            return retrievedProjectTask;
        }

        public ProjectTask Update(ProjectTask updatedProjectTaskData)
        {            
            var existingProjectTask = GetProjectTask(updatedProjectTaskData.ID);
            if (existingProjectTask == null)
            {
                return null;
            }

            projectTasksList.Remove(existingProjectTask);
            projectTasksList.Add(updatedProjectTaskData);

            return GetProjectTask(updatedProjectTaskData.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            var retrievedTask = GetProjectTask(ID);
            if (retrievedTask != null)
            {
                projectTasksList.Remove(retrievedTask);
                isSuccess = true;
            }
            return isSuccess;
        }

        ProjectTask GetProjectTask(int ID)
        {
            var retrievedProjectTask = projectTasksList.FirstOrDefault(projectTask => projectTask.ID == ID);
            if (retrievedProjectTask == default(ProjectTask))
            {
                return null;
            }
            return retrievedProjectTask;
        }
    }
}
