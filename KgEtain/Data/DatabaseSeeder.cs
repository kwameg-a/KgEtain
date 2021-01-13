using KgEtain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KgEtain.Data
{
    public class DatabaseSeeder
    {
        public async static Task Seed(AppDbContext context, IApplicationBuilder app)
        {
            await context.Database.EnsureCreatedAsync();

            #region Seed User
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!context.Users.Any(u => u.Email == "test@test.com"))
                {
                    var user = new AppUser
                    {
                        Email = "test@test.com",
                        UserName = "test@test.com",
                        EmailConfirmed = true,
                        
                    };
                    await userManager.CreateAsync(user, "Password1!");                    
                }               
            }
            #endregion

            await context.SaveChangesAsync();
        }
    }
}
