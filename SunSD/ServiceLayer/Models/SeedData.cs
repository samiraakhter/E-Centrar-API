using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ServiceLayer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SunSDContext(
                serviceProvider.GetRequiredService<DbContextOptions<SunSDContext>>()))
            {
                // Look for any movies.
                if (context.Admin.Any())
                {
                    return;   // DB has been seeded
                }

                context.Admin.AddRange(
                    new Admin
                    {
                        AdminId = Guid.NewGuid(),
                        AdminName = "Sameera",
                        CreatedBy = "default",
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Email = "sam@abc.com",
                        Password = "123",
                        UserName = "sam123"

                    });
                context.SaveChanges();
            }
        }
    }
}