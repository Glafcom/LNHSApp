using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LNHSApp.DAL.AppDbContext.LNHSAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LNHSApp.DAL.AppDbContext.LNHSAppDbContext context)
        {
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Name = RoleType.Admin },
                new Role { Name = RoleType.Player },
                new Role { Name = RoleType.TournamentAdmin }

             );

            var userStore = new UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>(context);
            var userManager = new UserManager<User, Guid>(userStore);

            if (!context.Users.Any(u => u.UserName == "SuperAdmin"))
            {
                var admin = new User
                {
                    Email = "little-beetle_88@mail.ru",
                    UserName = "SuperAdmin",
                    Name = "Super",
                    Surname = "Admin"
                };

                userManager.Create(admin, "admin123");
                userManager.AddToRole(admin.Id, RoleType.Admin);
            }

            context.SaveChanges();
        }
    }
}

