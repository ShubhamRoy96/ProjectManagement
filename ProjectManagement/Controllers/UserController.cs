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
    public class UserController : ControllerBase, IBaseController
    {
        List<User> usersList = new List<User>()
        {
            new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401" },
            new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401" },
            new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401" },
            new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401" }
        };

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
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
        public void RetrieveOne()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
