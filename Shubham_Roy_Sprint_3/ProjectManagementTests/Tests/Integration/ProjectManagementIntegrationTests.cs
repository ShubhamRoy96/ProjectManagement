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
using ProjectManagementTests;

namespace ProjectManagement.Tests.Integration
{
    public class IntegrationTests : IClassFixture<ProjectManagementWebApplicationFactory<ProjectManagement.Startup>>
    {
        readonly ProjectManagementWebApplicationFactory<ProjectManagement.Startup> _appFactory;
        readonly ITestOutputHelper _output;

        public IntegrationTests(ProjectManagementWebApplicationFactory<ProjectManagement.Startup> webApplicationFactory, ITestOutputHelper output)
        {
            _appFactory = webApplicationFactory;
            _output = output;
        }

        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, "Test project A", "Test project A for testing")]
        public async void CreateProject_shouldReturnOk(int id, string name, string detail)
        {
            var url = "/api/Project";
            var client = _appFactory.CreateClient();
            var testProject = new Project()
            {
                ID = id,
                Name = name,
                Detail = detail
            };
            var serializedData = JsonSerializer.Serialize(testProject);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (Project)response.Content.ReadFromJsonAsync(typeof(Project)).Result;
            Assert.Equal(testProject.Name, responseData.Name);

            TestFunctions.Cleanup(_appFactory, "Project", id);

        }

        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, 20, 30, 1)]
        public async void CreateTask_shouldReturnOK(int id, int projectID, int assignedUserId, int status)
        {
            var url = "/api/Task";
            var client = _appFactory.CreateClient();

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
            var response = await client.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (ProjectTask)response.Content.ReadFromJsonAsync(typeof(ProjectTask)).Result;
            Assert.Equal(testProjectTask.Detail, responseData.Detail);

            TestFunctions.Cleanup(_appFactory, "Task", id);
        }

        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public async void CreateUser_shouldRetrunOK(int id, string firstName, string lastName, string email, string password)
        {
            var url = "/api/User";
            var client = _appFactory.CreateClient();

            var testUser = new User()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };
            var serializedData = JsonSerializer.Serialize(testUser);
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var responseData = (User)response.Content.ReadFromJsonAsync(typeof(User)).Result;
            Assert.Equal(testUser.FirstName, responseData.FirstName);

            TestFunctions.Cleanup(_appFactory, "User", id);
        }

        [Trait("Integration", "Retrieval")]
        [Theory]
        [InlineData("api/Project")]
        [InlineData("api/Task")]
        [InlineData("api/User")]
        public async void CheckAll_GET_Endpoints_allGETEndPointsShouldBeReachable(string url)
        {
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async void CheckLoginAuthentication_shouldBeableToLogIn()
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

        [Trait("Integration", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public async void GetProjectByID_shouldReturnProjectWithGivenID(int id)
        {
            var url = $"/api/Project/{id}";
            var client = _appFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = (Project)response.Content.ReadFromJsonAsync(typeof(Project)).Result;
            Assert.Equal(id, responseData.ID);
        }

        [Trait("Integration", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public async void GetTaskByID_shouldReturnTaskWithGivenID(int id)
        {
            var url = $"/api/Task/{id}";
            var client = _appFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = (ProjectTask)response.Content.ReadFromJsonAsync(typeof(ProjectTask)).Result;
            Assert.Equal(id, responseData.ID);
        }

        [Trait("Integration", "Retrieval")]
        [Theory]
        [InlineData(2)]
        public async void GetUserByID_shouldReturnUserWithGivenID(int id)
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
        [InlineData(30)]
        public async void DeleteProject_shouldReturnOK(int id)
        {
            var url = $"/api/Project?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var createUrl = "/api/Project";            
            var testProject = new Project()
            {
                ID = id,
                Name = "test1",
                Detail = "detail1"
            };
            var serializedData = JsonSerializer.Serialize(testProject);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            await client.PostAsync(createUrl, httpContent);

            
            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(30)]
        public async void DeleteTask_shouldReturnOK(int id)
        {
            var url = $"/api/Task?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var createUrl = "/api/Task";
            var testTask = new ProjectTask()
            {
                ID = id,
                Detail = "detail1",
                ProjectID = id,
                AssignedToUserID = id,
                Status = 1
            };
            var serializedData = JsonSerializer.Serialize(testTask);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            await client.PostAsync(createUrl, httpContent);

            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Trait("Integration", "Deletion")]
        [Theory]
        [InlineData(30)]
        public async void DeleteUser_shouldReturnOK(int id)
        {
            var url = $"/api/User?ID={id}";
            var client = _appFactory.CreateClient();
            var authBearerToken = await TestFunctions.GetAuthBearerToken(_appFactory);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);

            var createUrl = "/api/User";
            var testUser = new User()
            {
                ID = id,
                FirstName = "test1",
                LastName = "test1",
                Email = "test1@gmail.com",
                Password = "test123"                
            };
            var serializedData = JsonSerializer.Serialize(testUser);
            var httpContent = new StringContent(serializedData, Encoding.UTF8, "application/json");
            await client.PostAsync(createUrl, httpContent);

            var response = await client.DeleteAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Trait("Integration", "Updation")]
        [Theory]
        [InlineData(3, "test 1", "detail 1")]
        public async void UpdateProject_shouldUpdateProjectWithGivenID(int id, string name, string detail)
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

        [Trait("Integration", "Updation")]
        [Theory]
        [InlineData(3, 10, 20, 2)]
        public async void UpdateProjectTask_shouldUpdateTaskWithGivenID(int id, int projectID, int assignedUserId, int status)
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

        [Trait("Integration", "Updation")]
        [Theory]
        [InlineData(3, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public async void UpdateUser_shouldUpdateUserWithGivenID(int id, string firstName, string lastName, string email, string password)
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

        [Trait("Integration", "Retrieval")]
        [Fact]
        public async void GetAllUsers_shouldReturnAllUsers()
        {
            var url = "/api/User";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<User>));
            List<User> allUsers = (List<User>)responseData;

            var mockTestUsers = TestFunctions.GetAllTestUsers();

            Assert.Equal(mockTestUsers.Count, allUsers.Count);
        }

        [Trait("Integration", "Retrieval")]
        [Fact]
        public async void GetAllProjects_shouldReturnAllProjects()
        {
            var url = "/api/Project";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<Project>));
            List<Project> allProjects = (List<Project>)responseData;

            var mockTestProjects = TestFunctions.GetAllTestProjects();

            Assert.Equal(mockTestProjects.Count, allProjects.Count);
        }

        [Trait("Integration", "Retrieval")]
        [Fact]
        public async void GetAllTasks_shouldReturnAllTasks()
        {
            var url = "/api/Task";
            var client = _appFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync(typeof(List<ProjectTask>));
            List<ProjectTask> allProjectTasks = (List<ProjectTask>)responseData;

            var mockTestProjectsTasks = TestFunctions.GetAllTestProjectTasks();
            Assert.Equal(mockTestProjectsTasks.Count, allProjectTasks.Count);
        }
    }
}
