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
    public class UserMockController : IRepository<User>
    {
        List<User> usersList = new List<User>()
        {
            new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401"},
            new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401"},
            new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401"},
            new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401"}
        };

        public User Create(User newUser)
        {
            if (GetUser(newUser.ID) == null)
            {
                usersList.Add(newUser);
            }
            else
                return null;
            return GetUser(newUser.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            var retrievedUser = GetUser(ID);
            if (retrievedUser != null)
            {
                usersList.Remove(retrievedUser);
                isSuccess = true;
            }
            
            return isSuccess;
        }

        public List<User> RetrieveAll()
        {
            return usersList;
        }

        public User RetrieveByID(int ID)
        {
            var retrievedUser = GetUser(ID);            
            return retrievedUser;
        }

        public User Update(User updatedUserData)
        {            
            var existingUser = GetUser(updatedUserData.ID);
            if (existingUser == null)
            {
                return null;
            }
            usersList.Remove(existingUser);
            usersList.Add(updatedUserData);
            return GetUser(updatedUserData.ID);
        }

        User GetUser(int ID)
        {
            var retrievedUser = usersList.FirstOrDefault(user => user.ID == ID);
            if (retrievedUser == default(User))
            {
                return null;
            }
            return retrievedUser;
        }
    }
}
