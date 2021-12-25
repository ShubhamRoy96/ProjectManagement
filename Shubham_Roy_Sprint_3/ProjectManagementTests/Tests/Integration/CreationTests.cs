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
    public class CreationTests : IClassFixture<WebApplicationFactory<ProjectManagement.Startup>>
    {
        readonly WebApplicationFactory<ProjectManagement.Startup> _appFactory;
        readonly ITestOutputHelper _output;

        public CreationTests(WebApplicationFactory<ProjectManagement.Startup> webApplicationFactory, ITestOutputHelper output)
        {
            _appFactory = webApplicationFactory;
            _output = output;
        }


        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, "Test project A", "Test project A for testing")]
        public async void CheckProjectCreation(int id, string name, string detail)
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
        }

        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, 20, 30, 1)]
        public async void CheckTaskCreation(int id, int projectID, int assignedUserId, int status)
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
        }

        [Trait("Integration", "Creation")]
        [Theory]
        [InlineData(10, "test A", "surname A", "emailA@gmail.com", "pwdA")]
        public async void CheckUserCreation(int id, string firstName, string lastName, string email, string password)
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
        }
    }
}
