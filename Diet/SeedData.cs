using Diet.Models;
using Microsoft.AspNetCore.Identity;

namespace Diet
{
    public class SeedData
    {
        public static async Task Seed(
          RoleManager<IdentityRole> roleManager
        )
        {
            await SeedRoles(roleManager);
        }

 
        public static async Task SeedRoles(
            RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Doctor").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Doctor",
                };
                var result = await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User",
                };
                var result = await roleManager.CreateAsync(role);
            }

        }
    }
}
