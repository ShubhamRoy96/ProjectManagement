using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class SeedDataGeneratorExtensions
    {
        public static void UseDataSeeder(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<SeedDataGenerator>();
        }
    }
}