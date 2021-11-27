using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IBaseController<User>
    {
        List<User> usersList = new List<User>()
        {
            new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401", UserType = "SuperUser" },
            new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401", UserType = "Normal" },
            new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401", UserType = "Normal" },
            new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401", UserType = "Normal" }
        };

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (GetUser(newUser.ID) == default(User))
                {
                    usersList.Add(newUser);
                    return Ok("User added successfully.");
                }
            }
            return BadRequest("Failed to add user");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveAll()
        {
            if (usersList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(usersList);
        }

        [HttpGet]
        [Route("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetrieveByID(int ID)
        {
            var retrievedUser = GetUser(ID);
            if (retrievedUser == default(User))
            {
                return NotFound("User not found.");
            }
            return Ok(retrievedUser);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(User updatedUserData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Insufficient data entered");
            }
            var newUpdatedUser = GetUser(updatedUserData.ID);
            if (newUpdatedUser == default(User))
            {
                return NotFound($"User ID {updatedUserData.ID} not found");
            }

            newUpdatedUser.FirstName = updatedUserData.FirstName;
            newUpdatedUser.LastName = updatedUserData.LastName;
            newUpdatedUser.Email = updatedUserData.Email;
            newUpdatedUser.Password = updatedUserData.Password;
            newUpdatedUser.UserType = updatedUserData.UserType;

            return Ok(newUpdatedUser);
        }

        User GetUser(int ID)
        {
            var retrievedUser = usersList.FirstOrDefault(user => user.ID == ID);
            return retrievedUser;
        }
    }
}
