using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementTests.Functions
{
    internal class TestFunctions
    {
        public static string BearerToken { get; set; }

        internal static bool CompareCollections<T>(List<T> actualDataCollection, List<T> mockDataCollection)
        {
            var count = 0;
            bool isCollectionEqual = true;
            foreach (var data in actualDataCollection)
            {
                if (!mockDataCollection[count].Equals(data))
                {
                    isCollectionEqual = false;
                    break;
                }
                count++;
            }

            return isCollectionEqual;
        }

        internal static async Task<string> GetAuthBearerToken(WebApplicationFactory<ProjectManagement.Startup> appFactory)
        {
            if (BearerToken != null && BearerToken != string.Empty)
            {
                return BearerToken;
            }
            var url = "api/Authentication/Login";
            var client = appFactory.CreateClient();

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
            response.EnsureSuccessStatusCode();

            var authToken = response.Content.ReadAsStringAsync().Result;
            BearerToken = authToken;
            return authToken;
        }

        internal static void Cleanup(WebApplicationFactory<ProjectManagement.Startup> appfactory, string cleanupFor, int ID)
        {
            var deleteUrl = $"/api/{cleanupFor}?ID={ID}";
            var authBearerToken = GetAuthBearerToken(appfactory).Result;
            var client = appfactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authBearerToken);
            var deleteResponse = client.DeleteAsync(deleteUrl);
        }

        internal static List<ProjectTask> GetAllTestProjectTasks()
        {
            return new List<ProjectTask>()
            {
                new ProjectTask(){ ID = 1, ProjectID = 1, Status = 1, AssignedToUserID = 1, Detail = "A task", CreatedOn = new DateTime(2021,12,1)},
                new ProjectTask(){ ID = 2, ProjectID = 2, Status = 2, AssignedToUserID = 2, Detail = "A good task", CreatedOn = new DateTime(2021,2,12)},
                new ProjectTask(){ ID = 3, ProjectID = 3, Status = 3, AssignedToUserID = 4, Detail = "A boring task", CreatedOn = new DateTime(2021,3,14)},
                new ProjectTask(){ ID = 4, ProjectID = 4, Status = 4, AssignedToUserID = 3, Detail = "An Awesome task!", CreatedOn = new DateTime(2021,5,21)},
            };
        }

        internal static List<User> GetAllTestUsers()
        {
            return new List<User>()
            {
                new User(){ ID = 1, FirstName = "Shubham", LastName = "Roy", Email = "shubhamroy896@gmail.com", Password = "NotMyActualGmailPassword@401"},
                new User(){ ID = 2, FirstName = "Amar", LastName = "Ojha", Email = "amar@gmail.com", Password = "NotAmarsActualGmailPassword@401"},
                new User(){ ID = 3, FirstName = "Akbar", LastName = "Shahpuri", Email = "akbar@gmail.com", Password = "NotAkabarsActualGmailPassword@401"},
                new User(){ ID = 4, FirstName = "Anthony", LastName = "Allen", Email = "anthony@gmail.com", Password = "NotAnthonysActualGmailPassword@401"}
            };
        }

        internal static List<Project> GetAllTestProjects()
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