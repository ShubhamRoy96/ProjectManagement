using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    public class UserInMemDBController : IRepository<User>
    {
        readonly ProjectManagementDbContext _dbContext;

        public UserInMemDBController(IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ProjectManagementDbContext>();
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return RetrieveByID(user.ID);
        }

        public bool Delete(int ID)
        {
            var isSuccess = false;
            try
            {
                var foundUser = RetrieveByID(ID);
                _dbContext.Users.Remove(foundUser);
                _dbContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        public List<User> RetrieveAll()
        {
            return _dbContext.Users.ToList();
        }

        public User RetrieveByID(int ID)
        {
            var foundUser = _dbContext.Users.FirstOrDefault(user => user.ID == ID);            
            return foundUser;
        }

        public User Update(User updatedUser)
        {
            var foundUser = RetrieveByID(updatedUser.ID);
            if (foundUser != null)
            {
                Delete(foundUser.ID);
                Create(updatedUser);
                _dbContext.SaveChanges();
            }
            return RetrieveByID(updatedUser.ID);

        }
    }
}
