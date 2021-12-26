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
using Microsoft.AspNetCore.Http;

namespace ProjectManagementTests.Tests.Unit
{
    public class ProjectManagementUnitTests : IDisposable
    {
        readonly ProjectManagementDbContext _dbContext;
        private readonly ProjectController projectController;
        private readonly TaskController taskController;
        private readonly UserController userController;

        static DbContextOptions<ProjectManagementDbContext> _dbContextOptions;

        public ProjectManagementUnitTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ProjectManagementDbContext>()
                .UseInMemoryDatabase("UnitTestDb")
                .Options;
            _dbContext = new ProjectManagementDbContext(_dbContextOptions);

            SeedDataGenerator.GenerateSeedData(_dbContext);

            projectController = new ProjectController(new ProjectInMemDBController(_dbContext));
            taskController = new TaskController(new TaskInMemDBController(_dbContext));
            userController = new UserController(new UserInMemDBController(_dbContext));
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
        [InlineData("SuperAdmin1", "SuperPwd1")]
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

        [Trait("Unit", "Creation")]
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

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = HostString.FromUriComponent("testhost");
            httpContext.Request.Path = PathString.FromUriComponent("/testpath");


            ProjectController customProjectController = new ProjectController(new ProjectInMemDBController(_dbContext))
            {

                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }

            };

            var response = customProjectController.Create(project);

            Assert.IsType<CreatedResult>(response);
            var createdProject = ((CreatedResult)response).Value;
            Assert.Equal(project, createdProject);
        }

        [Trait("Unit", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public void GetProjectByID_shouldReturnProjectWithGivenID(int id)
        {
            var response = projectController.RetrieveByID(id);

            Assert.IsType<OkObjectResult>(response);
            var retrievedProject = (Project)(((OkObjectResult)response).Value);
            Assert.Equal(id, retrievedProject.ID);
        }

        [Trait("Unit", "Retrieval")]
        [Fact]
        public void GetAllProjects_shouldReturnAllProjects()
        {
            var response = projectController.RetrieveAll();

            Assert.IsType<OkObjectResult>(response);
            var dataCount = ((List<Project>)(((OkObjectResult)response).Value)).Count;
            Assert.Equal(4, dataCount);
        }

        [Trait("Unit", "Updation")]
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
            Assert.IsType<OkObjectResult>(response);
            var updatedProject = (Project)((OkObjectResult)response).Value;
            Assert.Equal(project, updatedProject);
        }

        [Trait("Unit", "Deletion")]
        [Theory]
        [InlineData(1)]
        public void DeleteProject_shouldReturnOK(int id)
        {
            var response = projectController.Delete(id);
            Assert.IsType<OkObjectResult>(response);
            Assert.IsType<NotFoundObjectResult>(projectController.RetrieveByID(id));
        }

        [Trait("Unit", "Creation")]
        [Theory]
        [InlineData(10, 20, 30, 1)]
        public void CreateTask_shouldReturnOK(int id, int projectID, int assignedUserId, int status)
        {
            var testProjectTask = new ProjectTask()
            {
                ID = id,
                ProjectID = projectID,
                Detail = $"Test Task {id}",
                AssignedToUserID = assignedUserId,
                Status = status
            };

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = HostString.FromUriComponent("testhost");
            httpContext.Request.Path = PathString.FromUriComponent("/testpath");

            TaskController customTaskController = new TaskController(new TaskInMemDBController(_dbContext))
            {

                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }

            };

            var response = customTaskController.Create(testProjectTask);

            Assert.IsType<CreatedResult>(response);
            var createdTask = ((CreatedResult)response).Value;
            Assert.Equal(testProjectTask, createdTask);
        }

        [Trait("Unit", "Retrieval")]
        [Fact]
        public void GetAllTasks_shouldReturnAllTasks()
        {
            var response = taskController.RetrieveAll();

            Assert.IsType<OkObjectResult>(response);
            var dataCount = ((List<ProjectTask>)(((OkObjectResult)response).Value)).Count;
            Assert.Equal(4, dataCount);
        }

        [Trait("Unit", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public void GetTaskByID_shouldReturnTaskWithGivenID(int id)
        {
            var response = taskController.RetrieveByID(id);

            Assert.IsType<OkObjectResult>(response);
        }

        [Trait("Unit", "Updation")]
        [Theory]
        [InlineData(3, 10, 20, 2)]
        public void UpdateProjectTask_shouldUpdateTaskWithGivenID(int id, int projectID, int assignedUserId, int status)
        {
            var testProjectTask = new ProjectTask()
            {
                ID = id,
                ProjectID = projectID,
                Detail = $"Test Task {id}",
                AssignedToUserID = assignedUserId,
                Status = status
            };

            var response = taskController.Update(testProjectTask);

            Assert.IsType<OkObjectResult>(response);
            var updatedProjectTask = (ProjectTask)((OkObjectResult)response).Value;
            Assert.Equal(testProjectTask, updatedProjectTask);
        }

        [Trait("Unit", "Deletion")]
        [Theory]
        [InlineData(4)]
        public void DeleteTask_shouldReturnOK(int id)
        {
            var response = taskController.Delete(id);

            Assert.IsType<OkObjectResult>(response);
            Assert.IsType<NotFoundObjectResult>(taskController.RetrieveByID(id));
        }

        [Trait("Unit", "Creation")]
        [Theory]
        [InlineData(10, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public void CreateUser_shouldRetrunOK(int id, string firstName, string lastName, string email, string password)
        {
            var testUser = new User()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = HostString.FromUriComponent("testhost");
            httpContext.Request.Path = PathString.FromUriComponent("/testpath");

            UserController customUserController = new UserController(new UserInMemDBController(_dbContext))
            {

                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }

            };

            var response = customUserController.Create(testUser);

            Assert.IsType<CreatedResult>(response);
            var createdUser = ((CreatedResult)response).Value;
            Assert.Equal(testUser, createdUser);
        }

        [Trait("Unit", "Retrieval")]
        [Fact]
        public void GetAllUsers_shouldReturnAllUsers()
        {
            var response = userController.RetrieveAll();

            Assert.IsType<OkObjectResult>(response);
            var dataCount = ((List<User>)(((OkObjectResult)response).Value)).Count;
            Assert.Equal(4, dataCount);
        }

        [Trait("Unit", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public void GetUserByID_shouldReturnUserWithGivenID(int id)
        {
            var response = userController.RetrieveByID(id);

            Assert.IsType<OkObjectResult>(response);
        }

        [Trait("Unit", "Updation")]
        [Theory]
        [InlineData(3, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public void UpdateUser_shouldUpdateUserWithGivenID(int id, string firstName, string lastName, string email, string password)
        {
            var testUser = new User()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };

            var response = userController.Update(testUser);

            Assert.IsType<OkObjectResult>(response);
            var updatedUser = (User)((OkObjectResult)response).Value;
            Assert.Equal(testUser, updatedUser);
        }

        [Trait("Unit", "Deletion")]
        [Theory]
        [InlineData(1)]
        public void DeleteUser_shouldReturnOK(int id)
        {
            var response = userController.Delete(id);

            Assert.IsType<OkObjectResult>(response);
            Assert.IsType<NotFoundObjectResult>(userController.RetrieveByID(id));
        }

    }
}
