using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models.Identity
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public override Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? IsBlocked { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
