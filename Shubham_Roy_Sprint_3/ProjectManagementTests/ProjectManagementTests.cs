using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using System.Linq;
using Domain.Entities;
using Xunit.Abstractions;
using ProjectManagementTests.Functions;

namespace ProjectManagement
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<ProjectManagement.Startup>>
    {
        readonly WebApplicationFactory<ProjectManagement.Startup> _appFactory;
        readonly ITestOutputHelper _output;

        public IntegrationTests(WebApplicationFactory<ProjectManagement.Startup> webApplicationFactory, ITestOutputHelper output)
        {
            _appFactory = webApplicationFactory;
            _output = output;
        }

        [Theory]
        [InlineData("api/Project")]
        [InlineData("api/Task")]
        [InlineData("api/User")]
        public async void CheckAll_GET_Endpoints(string url)
        {
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async void CheckLoginAuthentication()
        {
            var url = "api/Authentication/Login";
            var client = _appFactory.CreateClient();
            var adminUser = new User()
            {
                ID = 0,
                FirstName = "SuperAdmin1",
                LastName = "lastname",
                Password = "SuperPwd1",
                Email = "email"
            };

            var serializedData = JsonSerializer.Serialize(adminUser);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);

            Assert.True(response.IsSuccessStatusCode, $"Request failed with response reason : {response.ReasonPhrase}");
        }


        

        [Theory]
        [InlineData(2)]
        public async void GetProjectByID(int id)
        {
            var url = $"/api/Project/{id}";
            var client = _appFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = (Project)response.Content.ReadFromJsonAsync(typeof(Project)).Result;
            Assert.Equal(id, responseData.ID);
        }

        [Theory]
        [InlineData(2)]
        public async void GetTaskByID(int id)
        {
            var url = $"/api/Task/{id}";
            var client = _appFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = (ProjectTask)response.Content.ReadFromJsonAsync(typeof(ProjectTask)).Result;
            Assert.Equal(id, responseData.ID);
        }

        [Theory]
        [InlineData(2)]
        public async void GetUserByID(int id)
        {
            var url = $"/api/User/{id}";
            var client = _appFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = (User)response.Content.ReadFromJsonAsync(typeof(User)).Result;
            Assert.Equal(id, responseData.ID);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(1)]
        public async void DeleteProject(int id)
        {
            var url = $"/api/Project?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(1)]
        public async void DeleteTask(int id)
        {
            var url = $"/api/Task?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(1)]
        public async void DeleteUser(int id)
        {
            var url = $"/api/User?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData(3, "test 1", "detail 1")]
        public async void UpdateProject(int id, string name, string detail)
        {
            var url = "/api/Project";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var testProject = new Project()
            {
                ID = id,
                Name = name,
                Detail = detail
            };

            var serializedData = JsonSerializer.Serialize(testProject);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (Project)response.Content.ReadFromJsonAsync(typeof(Project)).Result;
            Assert.Equal(testProject.Name, responseData.Name);
        }

        [Theory]
        [InlineData(3, 10, 20, 2)]
        public async void UpdateProjectTask(int id, int projectID, int assignedUserId, int status)
        {
            var url = "/api/Task";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var testProjectTask = new ProjectTask()
            {
                ID = id,
                ProjectID = projectID,
                Detail = $"Test Task {id}",
                AssignedToUserID = assignedUserId,
                Status = status
            };

            var serializedData = JsonSerializer.Serialize(testProjectTask);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (ProjectTask)response.Content.ReadFromJsonAsync(typeof(ProjectTask)).Result;
            Assert.Equal(testProjectTask.Detail, responseData.Detail);
        }

        [Theory]
        [InlineData(3, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public async void UpdateUser(int id, string firstName, string lastName, string email, string password)
        {
            var url = "/api/User";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);


            var testUser = new User()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };

            var serializedData = JsonSerializer.Serialize(testUser);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (User)response.Content.ReadFromJsonAsync(typeof(User)).Result;
            Assert.Equal(testUser.FirstName, responseData.FirstName);
        }

        [Fact]
        public async void GetAllUsers()
        {
            var url = "/api/User";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<User>));
            List<User> allUsers = (List<User>)responseData;

            var mockTestUsers = GetAllTestUsers();
            bool isCollectionEqual = TestFunctions.CompareCollections(allUsers, mockTestUsers);
            Assert.True(isCollectionEqual);
        }

        [Fact]
        public async void GetAllProjects()
        {
            var url = "/api/Project";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<Project>));
            List<Project> allProjects = (List<Project>)responseData;

            var mockTestProjects = GetAllTestProjects();
            bool isCollectionEqual = TestFunctions.CompareCollections(allProjects, mockTestProjects);
            Assert.True(isCollectionEqual);
        }

        

        [Fact]
        public async void GetAllTasks()
        {
            var url = "/api/Task";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<ProjectTask>));
            List<ProjectTask> allProjectTasks = (List<ProjectTask>)responseData;

            var mockTestProjectsTasks = GetAllTestProjectTasks();
            bool isCollectionEqual = TestFunctions.CompareCollections(allProjectTasks, mockTestProjectsTasks);
            Assert.True(isCollectionEqual);
        }

        private List<ProjectTask> GetAllTestProjectTasks()
        {
            return new List<ProjectTask>()
        {
            new ProjectTask(){ ID = 1, ProjectID = 1, Status = 1, AssignedToUserID = 1, Detail = "A task", CreatedOn = new DateTime(2021,12,1)},
            new ProjectTask(){ ID = 2, ProjectID = 2, Status = 2, AssignedToUserID = 2, Detail = "A good task", CreatedOn = new DateTime(2021,2,12)},
            new ProjectTask(){ ID = 3, ProjectID = 3, Status = 3, AssignedToUserID = 4, Detail = "A boring task", CreatedOn = new DateTime(2021,3,14)},
            new ProjectTask(){ ID = 4, ProjectID = 4, Status = 4, AssignedToUserID = 3, Detail = "An Awesome task!", CreatedOn = new DateTime(2021,5,21)},
        };
        }

        List<User> GetAllTestUsers()
        {
            return new List<User>() 
            { 
                new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401"},
                new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401"},
                new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401"},
                new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401"}
            };
        }

        private List<Project> GetAllTestProjects()
        {
            return new List<Project>()
            {
                new Project(){ ID = 1, Name = "Project 1", Detail = "An Awesome project!", CreatedOn = new DateTime(2020,11,1) },
                new Project(){ ID = 2, Name = "Project 2", Detail = "Another Awesome project!", CreatedOn = new DateTime(2020,1,12) },
                new Project(){ ID = 3, Name = "Project 3", Detail = "A moderate project", CreatedOn = new DateTime(2021,3,5) },
                new Project(){ ID = 4, Name = "Project 4", Detail = "A small project", CreatedOn = new DateTime(2021,9,3) }
            };
        }

    }
}
