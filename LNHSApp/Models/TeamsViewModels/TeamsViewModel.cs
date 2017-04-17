using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.TeamsViewModels
{
    public class TeamsViewModel
    {
        public TeamFilter Filter { get; set; }
        public ICollection<TeamViewModel> TeamsList { get; set; }
    }
}