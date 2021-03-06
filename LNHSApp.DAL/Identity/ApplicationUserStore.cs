﻿using LNHSApp.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.DAL.Identity
{
    public class ApplicationUserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        { }
    }
}
