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
    public class TaskController : ControllerBase
    {
        readonly IRepository<ProjectTask> _repository;
        public TaskController(IRepository<ProjectTask> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ProjectTask newProjectTask)
        {
            return _repository.Create(newProjectTask);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            return _repository.RetrieveByID(ID);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(ProjectTask updatedProjectTaskData)
        {
            return _repository.Update(updatedProjectTaskData);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectTask))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            return _repository.Delete(ID);
        }
    }
}
