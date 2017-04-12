using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ZenithSociety.Models
{
    public static class RoleData
    {
        public static async void Initialize(IServiceProvider isp)
        {
            var context = isp.GetService<ApplicationDbContext>();
            var roleStore = new RoleStore<ApplicationRole>(context);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                await roleStore.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                    Description = "Administartor",
                    CreatedDate = DateTime.Now,
                    NormalizedName = "ADMIN"
                });
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                await roleStore.CreateAsync(new ApplicationRole
                {
                    Name = "Member",
                    Description = "Members",
                    CreatedDate = DateTime.Now,
                    NormalizedName = "MEMBER"
                });
            }

            var admin = new ApplicationUser
            {
                FirstName = "AAA",
                LastName = "AAA",
                Email = "a@a.a",
                NormalizedEmail = "A@A.A",
                UserName = "a",
                NormalizedUserName = "P",
                PhoneNumber = "604-435-7689",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var member = new ApplicationUser
            {
                FirstName = "BBB",
                LastName = "BBB",
                Email = "b@b.b",
                NormalizedEmail = "B@B.B",
                UserName = "b",
                NormalizedUserName = "B",
                PhoneNumber = "778-223-4441",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(admin, "P@$$w0rd");
                admin.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(admin);
            }

            if (!context.Users.Any(u => u.UserName == member.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(member, "P@$$w0rd");
                member.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(member);
                await AssignRoles(isp, admin.UserName, "Admin");
                await AssignRoles(isp, member.UserName, "Member");
            }

            await context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string username, string role)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            var result = await _userManager.AddToRoleAsync(user, role);

            return result;
        }
    }
}
