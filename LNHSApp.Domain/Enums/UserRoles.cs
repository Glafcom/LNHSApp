﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Enums
{
    public enum UserRoles
    {
        Admin,
        Player,
        [Description("Tournament admin")]
        TournamentAdmin
    }
}
