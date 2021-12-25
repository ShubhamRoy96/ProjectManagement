using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementTests.Functions
{
    class TestFunctions
    {
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
            return authToken;
        }
    }
}
