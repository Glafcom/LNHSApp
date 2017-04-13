using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.TablesViewModels
{
    public class HockeyTablesViewModel
    {
        public HockeyTableFilter Filter { get; set; }
        public IEnumerable<HockeyTableViewModel> HockeyTablesList { get; set; }
    }
}