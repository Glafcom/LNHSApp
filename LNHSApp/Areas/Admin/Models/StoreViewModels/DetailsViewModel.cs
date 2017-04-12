using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.StoreViewModels
{
    public class DetailsViewModel
    {
        public DetailFilter Filter { get; set; }
        public IEnumerable<DetailViewModel> DetailsList { get; set; }
    }
}