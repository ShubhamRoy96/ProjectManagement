using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                var createdUser = _repository.Create(newUser);
                return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{HttpContext.Request.Path}/{createdUser.ID}", createdUser);
            }
            return BadRequest("Failed to add user");
        }

        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            var isSuccess = _repository.Delete(ID);
            if (!isSuccess)
            {
                return NotFound($"User {ID} not found");
            }
            return Ok($"User {ID} deleted successfully");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            var allUsers = _repository.RetrieveAll();

            if (allUsers.Count <= 0)
            {
                return NotFound("No Users found");
            }
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var foundUser = _repository.RetrieveByID(ID);
                        
            if (foundUser == null)
            {
                return NotFound("User not found.");
            }
            return Ok(foundUser);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(User updatedUserData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var updatedData = _repository.Update(updatedUserData);
            if (updatedData == null)
            {
                return NotFound($"User {updatedUserData.ID} not found");
            }
            return Ok(updatedData);
        }
    }
}
