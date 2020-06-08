using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeWebsite.Models
{

    public static class SeedDataIdentity
    {
        private const string adminRoleName = "Admin";
        private const string managerRoleName = "admin";

        private const string adminUser = "Amel";
        private const string adminPassword = "Secret123$";

        private const string managerUser = "Tahir";
        private const string managerPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // Creates and Initialize a RoleManager obj, to help create Role.
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            //admin role
            IdentityRole adminRole = await roleManager.FindByNameAsync(adminRoleName);

            if (adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                await roleManager.CreateAsync(adminRole);
            }

            //manager role
            IdentityRole managerRole = await roleManager.FindByNameAsync(managerRoleName);

            if (managerRole == null)
            {
                managerRole = new IdentityRole(managerRoleName);
                await roleManager.CreateAsync(managerRole);
            }



            // Creates and Initialize a UserManager obj, to help create User.
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            //admin user
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(user, adminRoleName)))
                {
                    await userManager.AddToRoleAsync(user, adminRoleName);
                }
            }

            //manager user
            IdentityUser managerUserIdentity = await userManager.FindByNameAsync(managerUser);

            if (managerUserIdentity == null)
            {
                managerUserIdentity = new IdentityUser(managerUser);
                await userManager.CreateAsync(managerUserIdentity, managerPassword);
                await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(managerUserIdentity, managerRoleName)))
                {
                    await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
                }
            }
            
        }
    }
}
