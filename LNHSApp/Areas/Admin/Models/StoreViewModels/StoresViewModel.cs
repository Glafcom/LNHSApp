using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.StoreViewModels
{
    public class StoresViewModel
    {
        public DetailFilter Filter { get; set; }
        public ICollection<StoreViewModel> StoresList { get; set; }
        public int HockeyTablesCount { get; set; }
    }
}