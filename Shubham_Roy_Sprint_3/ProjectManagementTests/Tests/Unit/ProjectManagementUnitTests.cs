using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjectManagement.Controllers;
using ProjectManagement.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Controllers.DBController;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementTests.Tests.Unit
{
    public class ProjectManagementUnitTests : IDisposable
    {
        readonly ProjectManagementDbContext _dbContext;
        private readonly ProjectInMemDBController projectController;
        private readonly TaskInMemDBController taskController;
        private readonly UserInMemDBController userCOntroller;
        static DbContextOptions<ProjectManagementDbContext> _dbContextOptions;

        public ProjectManagementUnitTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ProjectManagementDbContext>()
                .UseInMemoryDatabase("UnitTestDb")
                .Options;
            _dbContext = new ProjectManagementDbContext(_dbContextOptions);

            SeedDataGenerator.GenerateSeedData(_dbContext);

            projectController =  new ProjectInMemDBController(_dbContext);
            taskController = new TaskInMemDBController(_dbContext);
            userCOntroller = new UserInMemDBController(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private static IActionResult GetLoginResponse(User adminUser)
        {
            AuthenticationController authController = new AuthenticationController(new JwtAuthticationManager("ThisIsAnAwesomeKeyForAnAwesomeApp!"));
            var response = authController.Login(adminUser);
            return response;
        }

        [Theory]
        [InlineData("SuperAdmin1","SuperPwd1")]
        [InlineData("SuperAdmin2", "SuperPwd2")]
        public void CheckLogin_shouldBeAbleToLogIn(string username, string password)
        {
            var adminUser = new User()
            {
                ID = 1,
                FirstName = username,
                LastName = "lastname",
                Password = password,
                Email = "email"
            };

            var response = GetLoginResponse(adminUser);

            Assert.IsType<OkObjectResult>(response);
        }

        [Theory]
        [InlineData("TestUser1", "TestPwsd1")]
        public void CheckLogin_shouldNotBeAbleToLogIn(string username, string password)
        {
            var nonAdminUser = new User()
            {
                ID = 1,
                FirstName = username,
                LastName = "lastname",
                Password = password,
                Email = "email"
            };

            var response = GetLoginResponse(nonAdminUser);

            Assert.IsType<UnauthorizedObjectResult>(response);
        }

        [Theory]
        [InlineData(30, "Test project A", "Test project A for testing")]
        public void CreateProject_shouldReturnOk(int id, string name, string detail)
        {
            var project = new Project()
            {
                ID = id,
                Name = name,
                Detail = detail
            };

            
            var responseEntity = projectController.Create(project);
            
            Assert.Equal(project, responseEntity);
        }

        [Trait("Integration", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public void GetProjectByID_shouldReturnProjectWithGivenID(int id)
        {
            var response = projectController.RetrieveByID(id);
            Assert.Equal(id, response.ID);
        }

        [Trait("Integration", "Retrieval")]
        [Fact]
        public void GetAllProjects_shouldReturnAllProjects()
        {
            var response = projectController.RetrieveAll();
            Assert.Equal(4, response.Count);
        }

        [Trait("Integration", "Updation")]
        [Theory]
        [InlineData(3, "test 1", "detail 1")]
        public void UpdateProject_shouldUpdateProjectWithGivenID(int id, string name, string detail)
        {            
            var project = new Project()
            {
                ID = id,
                Name = name,
                Detail = detail
            };

            var response = projectController.Update(project);
            Assert.Equal(project, response);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(1)]
        public void DeleteProject_shouldReturnOK(int id)
        {
            var response = projectController.Delete(id);
            Assert.True(response);
        }
    }
}
