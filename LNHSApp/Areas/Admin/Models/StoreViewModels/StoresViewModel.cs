using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.StoreViewModels
{
    public class StoresViewModel
    {
        public DetailFilters Filter { get; set; }
        public IEnumerable<StoreViewModel> DetailsList { get; set; }
    }
}