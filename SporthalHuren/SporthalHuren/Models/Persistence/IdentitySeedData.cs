using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SporthalHuren.Models
{
    public class IdentitySeedData
    {
        private const string adminEmail = "admin@sporthalhuren.nl";
        private const string adminPassword = "Welkom1!";
        private const string adminRole = "Administrator";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationUser user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, adminRole);
            }
            
        }
    }
}
