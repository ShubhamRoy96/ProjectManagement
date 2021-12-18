using Microsoft.AspNetCore.Authorization;
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
    public class ProjectController : ControllerBase
    {
        readonly IRepository<Project> _repository;
        public ProjectController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Project newProject)
        {
            if (ModelState.IsValid)
            {
                var createdProject = _repository.Create(newProject);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{HttpContext.Request.Path}/{createdProject.ID}", createdProject);
            }
            return BadRequest("Failed to add Project");
        }

        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            var isSuccess = _repository.Delete(ID);
            if (!isSuccess)
            {
                return NotFound($"Project {ID} not found");
            }
            return Ok($"Project {ID} deleted successfully");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            var allProjects = _repository.RetrieveAll();

            if (allProjects.Count <= 0)
            {
                return NotFound("No Projects found");
            }
            return Ok(allProjects);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var foundProject = _repository.RetrieveByID(ID);

            if (foundProject == null)
            {
                return NotFound("Project not found.");
            }
            return Ok(foundProject);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Project updatedProjectData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var updatedData = _repository.Update(updatedProjectData);
            if (updatedData == null)
            {
                return NotFound($"Project {updatedProjectData.ID} not found");
            }            
            return Ok(updatedData);
        }
    }
}
