using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectMockController : ControllerBase, IRepository<Project>
    {
        List<Project> projectsList = new List<Project>()
        {
            new Project(){ ID = 1, Name = "Project 1", Detail = "An Awesome project!", CreatedOn = new DateTime(2020,11,1) },
            new Project(){ ID = 2, Name = "Project 2", Detail = "Another Awesome project!", CreatedOn = new DateTime(2020,1,12) },
            new Project(){ ID = 3, Name = "Project 3", Detail = "A moderate project", CreatedOn = new DateTime(2021,3,5) },
            new Project(){ ID = 4, Name = "Project 4", Detail = "A small project", CreatedOn = new DateTime(2021,9,3) }
        };

        public Project Create(Project newProject)
        {
            if (GetProject(newProject.ID) == null)
            {
                projectsList.Add(newProject);
            }
            else
                return null;
            return GetProject(newProject.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            var retrievedProject = GetProject(ID);
            if (retrievedProject != null)
            {
                projectsList.Remove(retrievedProject);
                isSuccess = true;
            }

            return isSuccess;
        }

        public List<Project> RetrieveAll()
        {
            return projectsList;
        }

        public Project RetrieveByID(int ID)
        {
            var retrievedProject = GetProject(ID);
            return retrievedProject;
        }

        public Project Update(Project updatedProjectData)
        {
            var existingProject = GetProject(updatedProjectData.ID);
            if (existingProject == null)
            {
                return null;
            }
            projectsList.Remove(existingProject);
            projectsList.Add(updatedProjectData);
            return GetProject(updatedProjectData.ID);
        }

        Project GetProject(int ID)
        {
            var retrievedProject = projectsList.FirstOrDefault(project => project.ID == ID);
            if (retrievedProject == default(Project))
            {
                return null;
            }
            return retrievedProject;
        }
    }
}
