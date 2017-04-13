using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.BreakingsViewModels
{
    public class BreakingsViewModel
    {
        public BreakingFilter Filter { get; set; }
        public IEnumerable<BreakingViewModel> BreakingsList { get; set; }
    }
}