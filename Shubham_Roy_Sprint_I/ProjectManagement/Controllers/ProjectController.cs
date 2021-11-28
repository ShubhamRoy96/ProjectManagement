using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase, IBaseController<Project>
    {
        List<Project> projectsList = new List<Project>()
        {
            new Project(){ ID = 1, Name = "Project 1", Detail = "An Awesome project!", CreatedOn = new DateTime(2020,11,1) },
            new Project(){ ID = 2, Name = "Project 2", Detail = "Another Awesome project!", CreatedOn = new DateTime(2020,1,12) },
            new Project(){ ID = 3, Name = "Project 3", Detail = "A moderate project", CreatedOn = new DateTime(2021,3,5) },
            new Project(){ ID = 4, Name = "Project 4", Detail = "A small project", CreatedOn = new DateTime(2021,9,3) }
        };

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Project newProject)
        {
            if (ModelState.IsValid)
            {
                if (GetProject(newProject.ID) == default(Project))
                {
                    newProject.CreatedOn = DateTime.Now;
                    projectsList.Add(newProject);
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + newProject.ID, newProject);
                }
            }
            return BadRequest("Failed to create Project");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            if (projectsList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(projectsList);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var retrievedProject = GetProject(ID);
            if (retrievedProject == default(Project))
            {
                return NotFound("Project not found.");
            }
            return Ok(retrievedProject);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Project updatedProjectData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var newUpdatedProject = GetProject(updatedProjectData.ID);
            if (newUpdatedProject == default(Project))
            {
                return NotFound($"Project ID {updatedProjectData.ID} not found");
            }

            newUpdatedProject.Name = updatedProjectData.Name;
            newUpdatedProject.Detail = updatedProjectData.Detail;
            newUpdatedProject.CreatedOn = updatedProjectData.CreatedOn;

            return Ok(newUpdatedProject);
        }

        Project GetProject(int ID)
        {
            var retrievedProject = projectsList.FirstOrDefault(Project => Project.ID == ID);
            return retrievedProject;
        }
    }
}
