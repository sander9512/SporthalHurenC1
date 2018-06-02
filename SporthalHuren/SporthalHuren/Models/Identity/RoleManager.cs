using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SporthalHuren.Models
{
    public class RoleManager 
    {

        public static async Task CreateRoles(IApplicationBuilder app)
        {
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            bool adminRole = await roleManager.RoleExistsAsync("Administrator");
            bool normalUserRole = await roleManager.RoleExistsAsync("NormalUser");
            bool proprietorRole = await roleManager.RoleExistsAsync("Proprietor");
            bool proprietorAdminRole = await roleManager.RoleExistsAsync("ProprietorAdmin");

            if (!adminRole)
            {
                var identityRole = new IdentityRole();
                identityRole.Name = "Administrator";
                await roleManager.CreateAsync(identityRole);
            }

            if (!normalUserRole)
            {
                var identityRole = new IdentityRole();
                identityRole.Name = "NormalUser";
                await roleManager.CreateAsync(identityRole);
            }

            if (!proprietorRole)
            {
                var identityRole = new IdentityRole();
                identityRole.Name = "Proprietor";
                await roleManager.CreateAsync(identityRole);
            }

            if (!proprietorAdminRole)
            {
                var identityRole = new IdentityRole();
                identityRole.Name = "ProprietorAdmin";
                await roleManager.CreateAsync(identityRole);
            }

        }
    }
}
