using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.Interfaces;

namespace ProjectManagement.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepository<ProjectTask> _repository;

        public TaskController(IRepository<ProjectTask> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ProjectTask newProjectTask)
        {
            if (ModelState.IsValid)
            {
                var createdTask = _repository.Create(newProjectTask);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{HttpContext.Request.Path}/{createdTask.ID}", createdTask);
            }
            return BadRequest("Failed to create ProjectTask");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            var retrievedTasks = _repository.RetrieveAll();
            if (retrievedTasks.Count <= 0)
            {
                return NotFound("No Tasks found");
            }
            return Ok(retrievedTasks);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var retrievedTask = _repository.RetrieveByID(ID);
            if (retrievedTask == null)
            {
                return NotFound("ProjectTask not found.");
            }
            return Ok(retrievedTask);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(ProjectTask updatedProjectTaskData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var newUpdatedProjectTask = _repository.Update(updatedProjectTaskData);
            if (newUpdatedProjectTask == null)
            {
                return NotFound($"ProjectTask ID {updatedProjectTaskData.ID} not found");
            }
            return Ok(newUpdatedProjectTask);
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            var isSuccess = _repository.Delete(ID);
            if (!isSuccess)
            {
                return NotFound($"Task {ID} not found");
            }
            return Ok($"Task {ID} deleted successfully");
        }
    }
}