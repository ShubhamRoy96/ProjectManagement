using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagement.Controllers
{
    public class UserMockController : ControllerBase, IRepository<User>
    {
        List<User> usersList = new List<User>()
        {
            new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401"},
            new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401"},
            new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401"},
            new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401"}
        };
                
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (GetUser(newUser.ID) == default(User))
                {
                    usersList.Add(newUser);                    
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + newUser.ID, newUser);
                }
            }
            return BadRequest("Failed to add user");
        }
                
        public IActionResult Delete(int ID)
        {
            var retrievedUser = GetUser(ID);
            if (retrievedUser == default(User))
            {
                return NotFound($"User {ID} not found");
            }
            usersList.Remove(retrievedUser);
            return Ok($"User {ID} deleted successfully");
        }
                
        public IActionResult RetrieveAll()
        {
            if (usersList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(usersList);
        }

        public IActionResult RetrieveByID(int ID)
        {
            var retrievedUser = GetUser(ID);
            if (retrievedUser == default(User))
            {
                return NotFound("User not found.");
            }
            return Ok(retrievedUser);
        }
        
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

            return Ok(newUpdatedUser);
        }

        User GetUser(int ID)
        {
            var retrievedUser = usersList.FirstOrDefault(user => user.ID == ID);
            return retrievedUser;
        }
    }
}
