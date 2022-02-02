using Microsoft.AspNetCore.Builder;

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