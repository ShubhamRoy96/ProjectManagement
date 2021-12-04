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
            return _repository.Create(newProject);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            return _repository.RetrieveByID(ID);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Project updatedProjectData)
        {
            return _repository.Update(updatedProjectData);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            return _repository.Delete(ID);
        }
    }
}
