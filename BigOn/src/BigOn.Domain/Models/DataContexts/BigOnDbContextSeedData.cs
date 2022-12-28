using BigOn.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BigOn.Domain.Models.DataContexts
{
    public static class BigOnDbContextSeedData
    {
        public static IApplicationBuilder SeedMembership(this IApplicationBuilder app)
        {
            return app;
            const string adminEmail = "kamran_aeff@mail.ru";
            const string adminUserName = "kamran_aeff";
            const string adminPassword = "123";
            const string roleName = "sa";

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BigOnDbContext>();

                db.Database.Migrate();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<BigonUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<BigonRole>>();

                var role = roleManager.FindByNameAsync(roleName).Result;

                if (role == null)
                {
                    role = new BigonRole
                    {
                        Name = roleName
                    };

                    roleManager.CreateAsync(role).Wait();
                }

                var user = userManager.FindByEmailAsync(adminEmail).Result;

                if (user == null)
                {
                    user = new BigonUser
                    {
                        Email = adminEmail,
                        UserName = adminUserName,
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, adminPassword).Wait();
                }

                if (userManager.IsInRoleAsync(user,roleName).Result == false)
                {
                    userManager.AddToRoleAsync(user, roleName).Wait();
                }
            }

            return app;
        }
    }
}
