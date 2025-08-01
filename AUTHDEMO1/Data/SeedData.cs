using AUTHDEMO1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AUTHDEMO1.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

         
            string[] roles = { "SuperAdmin", "Admin", "HR", "Accounts", "Operations" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var superAdminEmail = "superadmin@example.com";
            var existingSuperAdmin = await userManager.FindByEmailAsync(superAdminEmail);
            if (existingSuperAdmin != null)
            {
                await userManager.DeleteAsync(existingSuperAdmin);
            }

            var superAdminUser = new ApplicationUser
            {
                UserName = superAdminEmail,
                Email = superAdminEmail,
                EmailConfirmed = true,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                FirstName = "Super",
                LastName = "Admin"

            };

            var superAdminResult = await userManager.CreateAsync(superAdminUser, "SuperAdmin@123");
            if (superAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
            }

         
            var adminEmail = "admin@example.com";
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin != null)
            {
                await userManager.DeleteAsync(existingAdmin);
            }

            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                FirstName = "System",
                LastName = "Admin"
            };

            var adminResult = await userManager.CreateAsync(adminUser, "Admin@123");
            if (adminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}

