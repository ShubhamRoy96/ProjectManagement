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
    public class TaskController : ControllerBase, IBaseController<ProjectTask>
    {
        List<ProjectTask> projectTasksList = new List<ProjectTask>()
        {
            new ProjectTask(){ ID = 1, ProjectID = 1, Status = 1, AssignedToUserID = 1, Detail = "A task", CreatedOn = new DateTime(2021,12,1)},
            new ProjectTask(){ ID = 2, ProjectID = 2, Status = 2, AssignedToUserID = 2, Detail = "A good task", CreatedOn = new DateTime(2021,2,12)},
            new ProjectTask(){ ID = 3, ProjectID = 3, Status = 3, AssignedToUserID = 4, Detail = "A boring task", CreatedOn = new DateTime(2021,3,14)},
            new ProjectTask(){ ID = 4, ProjectID = 4, Status = 4, AssignedToUserID = 3, Detail = "An Awesome task!", CreatedOn = new DateTime(2021,5,21)},
        };

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ProjectTask newProjectTask)
        {
            if (ModelState.IsValid)
            {
                if (GetProjectTask(newProjectTask.ID) == default(ProjectTask))
                {
                    newProjectTask.CreatedOn = DateTime.Now;
                    projectTasksList.Add(newProjectTask);
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + newProjectTask.ID, newProjectTask);
                }
            }
            return BadRequest("Failed to create ProjectTask");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            if (projectTasksList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(projectTasksList);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var retrievedProjectTask = GetProjectTask(ID);
            if (retrievedProjectTask == default(ProjectTask))
            {
                return NotFound("ProjectTask not found.");
            }
            return Ok(retrievedProjectTask);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(ProjectTask updatedProjectTaskData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var newUpdatedProjectTask = GetProjectTask(updatedProjectTaskData.ID);
            if (newUpdatedProjectTask == default(ProjectTask))
            {
                return NotFound($"ProjectTask ID {updatedProjectTaskData.ID} not found");
            }

            newUpdatedProjectTask.ID = updatedProjectTaskData.ID;
            newUpdatedProjectTask.ProjectID = updatedProjectTaskData.ProjectID;
            newUpdatedProjectTask.Status = updatedProjectTaskData.Status;
            newUpdatedProjectTask.AssignedToUserID = updatedProjectTaskData.AssignedToUserID;
            newUpdatedProjectTask.Detail = updatedProjectTaskData.Detail;
            newUpdatedProjectTask.CreatedOn = updatedProjectTaskData.CreatedOn;

            return Ok(newUpdatedProjectTask);
        }

        ProjectTask GetProjectTask(int ID)
        {
            var retrievedProjectTask = projectTasksList.FirstOrDefault(ProjectTask => ProjectTask.ID == ID);
            return retrievedProjectTask;
        }
    }
}
