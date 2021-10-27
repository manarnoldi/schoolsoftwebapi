using Microsoft.AspNetCore.Identity;
using SchoolSoftWeb.Constants;
using SchoolSoftWeb.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.HeadTeacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Teacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Parent.ToString()));

            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = Authorization.default_username,
                Email = Authorization.default_email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "SchoolSoft",
                LastName = "Administrator",
                PhoneNumber = "+254724920000"
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.default_password);
                await userManager.AddToRoleAsync(defaultUser, Authorization.default_role.ToString());
            }
        }
    }
}
