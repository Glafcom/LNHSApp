using LNHSApp.Domain.Models.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.DALContracts.Interfaces.Identity
{
    public interface IApplicationSignInManager
    {
        Task SignInAsync(User user, bool isPersistent, bool rememberBrowser);
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
    }
}
