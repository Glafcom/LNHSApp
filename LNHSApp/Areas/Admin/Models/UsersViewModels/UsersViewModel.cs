using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.UsersViewModels
{
    public class UsersViewModel
    {
        public UserFilter Filter { get; set; }
        public IEnumerable<UserViewModel> UsersList { get; set; }
    }
}